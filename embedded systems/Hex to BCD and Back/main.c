#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
#include "misc.h"
#include "muxled.h"

/********************************************************************/
// Main Entry
/********************************************************************/

void main(void)
{
  unsigned int values[2][10]=
  {
    {0,0x270f,0x2710,0x000f,0x00ff,0x0fff,0xffff,0x000a,0x0010,0xd321},//for hex to bcd
    {0,0x9999,0x10000,0x0015,0x0255,0x4095,0x00b1,0x0010,0x000a,0xabcd}//for bcd to hex
  };

  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  MuxLEDInit();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {    
    int j;
    unsigned int convert;  

    for ( j = 0; j < 10; j++)
    {
      //if able to convert to BCD run
      if(NumToBCD16(values[0][j],&convert)==BCD_OK)
      {
        MuxLEDOut16D(convert,one);
        delay(100);
      }
      else
      {
        //else an error responce code is given
        MuxLEDOut16A(0xFFFF);
      }
      //run if able to convert to hex val
      if(BCDToNum16(values[1][j],&convert)==BCD_OK)
      {
        MuxLEDOut16B(convert);
        delay(100);
      }
      else
      {
        //else an error responce code is given
        MuxLEDOut16B(0xFFFF);
      }
    }    
  }                   
}