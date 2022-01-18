/********************************************************************/
// HC12 Program:  lab02 - switch counters
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
//#include "misc.h"
#include "muxled.h"
#include "sw_led.h"

/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int count = 0;
unsigned int bounceCount = 0;
unsigned char state = 0;
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
  SWL_Init ();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(PT1AD1 & SWL_UP)
    {
      count++;
      MuxLEDOut16D(count,0);
    }
    if(PT1AD1 & SWL_DOWN)//reset to zero
    {
      count = 0;
      MuxLEDOut16D(count,0);
    }
    //compare center button with state varaible
    if((PT1AD1 & SWL_CTR)!=state)
    {
      bounceCount++;
      MuxLEDOut16D(bounceCount,1);
      state=!state;
    }    
  }                   
}