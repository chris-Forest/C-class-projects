/********************************************************************/
// HC12 Program:  Switchs and led with librarys
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       using .h files and .c files turn leds on and off
/********************************************************************/

#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
#include "sw_led.h"

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
  {   // if left is pressed turn red led on
      if(PT1AD1 & SWL_LEFT)
      {
        SWL_LED_ON(SWL_RED);
      }
      // if center is pressed turn yellow led on
      else if(PT1AD1 & SWL_CTR)
      {
        SWL_LED_ON(SWL_YELLOW);
      }
      // if right is pressed turn green led on
      else if(PT1AD1 & SWL_RIGHT)
      {
        SWL_LED_ON(SWL_GREEN);
      }
      // if up is pressed turn all led on
      else if(PT1AD1 & SWL_UP)
      {
        SWL_LED_ON(SWL_RED);
        SWL_LED_ON(SWL_GREEN);
        SWL_LED_ON(SWL_YELLOW);
      } 
      // if down is pressed turn all led of       
      else if(PT1AD1 & SWL_DOWN)
      {
        SWL_LED_OFF(SWL_RED);
        SWL_LED_OFF(SWL_GREEN);
        SWL_LED_OFF(SWL_YELLOW);
      }
  }                   
}