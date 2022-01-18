/********************************************************************/
// HC12 Program:  lab1-timed leds
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        chris forest
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

#include "sw_led.h"
/********************************************************************/
// Global Variables
/********************************************************************/
 //initalized varibles for loops
int j;
int i;
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
  SWL_Init();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {       
    // loop for every lsb itteration
    for( j = 0; j<4; j++)
    {
      // a 1sec delay loop 100ms
       for( i=0;i<100;i++)
      {
        asm LDX #26667;
        asm dbne X,*;   
      }
      PT1AD1+=0b01000000; // add first lsb
    }
    //toggle to next lsb
    SWL_LED_TOG(SWL_GREEN);
  }                   
}