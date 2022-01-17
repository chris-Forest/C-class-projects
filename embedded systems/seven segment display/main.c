/********************************************************************/
// HC12 Program:  7seg and led with librarys
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       using .h files and .c files display numbers
                  
// Date:          sept. 15 2020

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
#include "muxled.h"
/********************************************************************/
// Global Variables
/********************************************************************/
 //initalized varibles for loops

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
  MuxLEDInit();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {  
      char j;
      int i;
      char val;
      // make 500ms delay
       for( i=0;i<50;i++)
      {
        asm LDX #26667;
        asm dbne X,*;   
      }
      // tester code to display 76543210
      for (j = 0; j < 7; j++)
      {
        MuxLEDOutNormal(j,val,MuxLED_DP_OFF);
        val--;
      }
      val=7;
  }                   
}