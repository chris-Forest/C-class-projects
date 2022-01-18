/********************************************************************/
// HC12 Program:  ica12 - interrupts
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       cause teminal inerrupt and wait for key stroke, 
//                have a message show in an endless loop slowly
                  
// Date:          november 2 2020

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
#include "misc.h"
#include "muxled.h"
//#include "sw_led.h"
#include "lcd.h"
#include "sci0_Lib.h"

void lcdStringDelay (char const * straddr);
/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  lcdInit();
  MuxLEDInit();
  (void) sci0_Init(8000000,9600);
  // set background color, clear screen  
  //sci0_txStr ("\x1b[47m\x1b[2J"); 
  sci0_SetIntFlag(SCI0CR2_RIE_MASK);//same as SCI0CR2_RIE=1;
  //sci0_SetIntFlag(SCI0CR2_TIE_MASK);//same as SCI0CR2_TIE=1;
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    asm WAI;
    lcdStringDelay("Tell me a story...");
    lcdClear();
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void lcdStringDelay (char const * straddr)
{
  while (*straddr!=0)
  {
    delay(250);
    lcdData(*straddr);
    straddr++;    
  }
}

interrupt VectorNumber_Vsci0 void ISR_sci0(void)
{
  // if(SCI0SR1_RDRF)
    MuxLEDOut8(2,sci0_Bread());
  //not need for this ica??
  // if(SCI0SR1_TDRE)
  //   sci0_txByte('*');
}