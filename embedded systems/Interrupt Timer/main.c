/********************************************************************/
// HC12 Program:  ica15 -  interrupt timer
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       cause interrupts for timer. count like a clock
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
//#include "misc.h"
#include "muxled.h"
//#include "sw_led.h"
//#include "lcd.h"
//#include "sci0_Lib.h"
#include "timer.h"

unsigned int seconds=0;
unsigned int msCounter=0;
//unsigned int minutes=0;
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
  timerinit(7,625,1,Timer_Pin_Disco);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    //ms counter hundreds seconds
    MuxLEDOut16D(msCounter,1);  
    if(msCounter>99)
    {
      msCounter=0; 
      ++seconds;
    }

    //seconds diplay
    MuxLEDOut16D(seconds,0);       
    if(seconds>59)
    {
      seconds=0;
      //++minutes;
    }
    //MuxLEDOut16D(minutes*100,0); 
    asm wai;
  }                   
}

interrupt VectorNumber_Vtimch0 void IOC0(void)
{
  TFLG1=TFLG1_C0F_MASK;

  //action
  ++msCounter;
  //rearm
  TC0+=625;
}