/////////////////////////////////////////////
// LTC2633 - Dual 12-bit I2C DAC Library
/////////////////////////////////////////////
#include <hidef.h>
#include "derivative.h"
#include "i2c.h"
#include "LTC2633.h"
int LTC2633_WriteChan (unsigned int Value, byte AddressOffset, LTC2633_CHAN_SELECT chan)
{
 // address the device
 if (I2C_SendAddressRW((byte)(LTC2633ADDR + AddressOffset), I2C_WRITE, I2C_WAIT))
 return -1;
 // send command (write chan, power up all)
 if (chan == LTC2633_CHAN_A)
 (void)I2C_WriteByte (0b00100000, I2C_NOSTOP); // P18, datasheet
 else if (chan == LTC2633_CHAN_B)
 (void)I2C_WriteByte (0b00100001, I2C_NOSTOP); // P18, datasheet
 else // assume all channels
 (void)I2C_WriteByte (0b00101111, I2C_NOSTOP); // P18, datasheet

 // send msb data (data is 12 bits, oddly, left aligned, P18, datasheet)
 (void)I2C_WriteByte ((unsigned char)(Value >> 4), I2C_NOSTOP); // 0x0123 becomes 0x12

 // send lsb data
 (void)I2C_WriteByte ((unsigned char)(Value << 4), I2C_STOP); // 0x0123 becomes 0x30

 return 0; // good condition
}