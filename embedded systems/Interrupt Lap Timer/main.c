/********************************************************************/
// HC12 Program:  lab6 -  interrupt stopwatch
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       cause interrupts for timer. count like a clock
//                check time with a portj interrupt
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
//#include "lcd.h"
//#include "sci0_Lib.h"
#include "timer.h"

unsigned int seconds=0;
unsigned int msCounter=0;
unsigned int minutes=0;
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
  //SWL_PortjInit();
  DDRJ&=0b11111100;//set as inputs pjo/pj1- 22.3.2.56 big pink
  PPSJ&=0b11111101; //rising edge for pjo/pj1- 22.3.2.59 big pink
  PIEJ|=0b00000011; //enable inerrupts- 22.3.2.60 big pink
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    //displays the number of 1/100th seconds
    MuxLEDOut16D(msCounter,1);  
    //MuxLEDOutNormal(5,(char)msCounter,MuxLED_DP_OFF);
    //TODO: fix for entire btm seg display
    //while not messing up display
    if(msCounter>59)
    {
      msCounter=0; 
      ++seconds;
    }

    //seconds diplay
    //MuxLEDOut16D(seconds,0);       
    if(seconds>59)
    {
      seconds=0;
      ++minutes;
    }
    //MuxLEDOut16D(minutes,0); 
    //MuxLEDOutNormal(1,(char)minutes,MuxLED_DP_ON);
    //MuxLEDOutNormal(3,(char)seconds,MuxLED_DP_OFF);
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
interrupt VectorNumber_Vportj void intj(void)
{
  //if pf0 press/released display min and sec
  if(PIFJ&0b00000001)
  {
    MuxLEDOut16D(seconds,0);  
    MuxLEDOutNormal(1,(char)minutes,MuxLED_DP_ON);
    // MuxLEDOutNormal(3,(char)seconds,MuxLED_DP_OFF);
    PIFJ |=0b00000001; //interrupt acknologed
  }
}