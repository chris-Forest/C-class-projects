///////////////////////////////////////////////////////////////////////////////////////////
// MPL3115 functions
///////////////////////////////////////////////////////////////////////////////////////////
#include <stdlib.h>
#include <stdio.h>
#include <hidef.h>
#include "derivative.h"

#include "MPL3115.h"
#include "i2c.h"

// support function (must be defined first)
void MPL3115_Write (unsigned char reg, unsigned char data)
{
  // send device address, intent to write
  if (I2C_SendAddressRW (MPL3115_ADDR, I2C_WRITE, I2C_WAIT))
    return;
  
  // write register address, more data, so no stop
  (void)I2C_WriteByte (reg, I2C_NOSTOP);
  
  // write data, not more data, so stop
  (void)I2C_WriteByte (data, I2C_STOP);
}

// support function (must be defined first)
unsigned char MPL3115_Read (unsigned char addr)
{
  unsigned char retVal = 0xFF;
  
  if (I2C_SendAddressRW (MPL3115_ADDR, I2C_WRITE, I2C_WAIT))
    return 0xFF;
  
  // write register address, more data, so no stop
  (void)I2C_WriteByte (addr, I2C_NOSTOP);
  
  // restart so we can change data direction to read
  I2C_IssueRestart ();
  
  // send device address with intent to read
  if (I2C_SendAddressRW (MPL3115_ADDR, I2C_READ, I2C_NOWAIT))
    return 0xFF;
  
  // read the register, reading only 1 byte, so NACK, 
  //  also, done, so free bus with stop
  (void)I2C_RXByte (&retVal, I2C_NACK, I2C_STOP);
            
  return retVal;  
}

void MPL3115_Init (void)
{
  // enable data flags in PT_DATA_CFG (P28, 7.7.1)
  MPL3115_Write (0x13, 0x03);
  
  // oversample x128 (512ms), barometer mode, not-raw, poll mode, go ACTIVE (P32, 7.17.1)
  MPL3115_Write (0x26, 0x39);
}
            
int MPL3115_TRdy (void)
{
  if (MPL3115_Read (0x00) & 0x02) // P22, 7.1.2.1 (TDR)
    return 1;
  return 0;
}
           
int MPL3115_PRdy (void)
{
  if (MPL3115_Read (0x00) & 0x04) // P22, 7.1.2.1 (PDR)
    return 1;
  return 0;
}
            
// returns registers as 0x04 MSB, 0x05 LSB
float MPL3115_GetT (void)
{
  static unsigned int retVal = 0x0000;
  
  retVal = MPL3115_Read (0x05); // 7.1.3
  retVal += MPL3115_Read (0x04) * 0x100;//pushweds 8 posistions
  
  return (char)(retVal>>8)+(1/16.0f*(((byte)retVal>>4)));
}

float MPL3115_GetP (void)
{
  //long needed
  static unsigned char retVal = 0x0000;
  // static unsigned char retVal2 = 0x0000;
  // static unsigned char retVal3 = 0x0000;

  retVal += MPL3115_Read (0x03)>>6;
  retVal += MPL3115_Read (0x02)<<2; 
  retVal += MPL3115_Read (0x01)<<10; // 7.1.3  
    
  // retVal1+=retVal2;
  // retVal1+=retVal3;

  //return conversion for pressusre
  return retVal; //TODO: may adjust to nave dp
  //return(retVal1>>18)+(1/4.0f*(((byte)retVal1>>4)));
}
