/********************************************************************/
// HC12 Program:  YourProg - MiniExplanation
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        This B. You
// Details:       A more detailed explanation of the program is entered here
                  
// Date:          Date Created
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
//#include "misc.h"
//#include "muxled.h"
//#include "sw_led.h"
//#include "lcd.h"
#include "sci0_Lib.h"

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
  (void) sci0_Init(8000000,9600);  
  sci0_txStr("Welcome to the world of serial communications!");
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    sci0_txByte(sci0_Bread());//waits for user input
  }               
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
