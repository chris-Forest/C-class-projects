/********************************************************************/
// HC12 Program:  ica17 - micro as a voltmeter
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       use micro board a a voltmeter with ATD0 pins for basic circuits on a breadboard
 /********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
#include <stdlib.h>
#include <stdio.h>
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
//#include "misc.h"
#include "muxled.h"
#include "sw_led.h"
#include "AtoD.h"
#include"timer.h"
#include"lcd.h"

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  float A0;
  float A1;
  unsigned int result=0;
  //char buff[11];//for n.nnn V format
  char buffA0[12];//for n.nnn V format
  char buffA1[12];//for n.nnn V format
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  AtoDInit(0);//set up for no minyerrputs , poll version
  timerinit(7,15625,0,Timer_Pin_Disco);//250ms sleep
  MuxLEDInit();
  lcdInit();
  SWL_Init();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    sleep(250);
    if(ATD0STAT0_SCF)
    {
      result=ATD0DR0;
      //do theese represent the pins we are using?
      A0=ATD0DR0*0.005;//*5mV
      A1=ATD0DR1*0.005; 
    }       

    if(A0>A1)
    {
      SWL_LED_ON(SWL_RED);
      SWL_LED_OFF(SWL_GREEN);
    }      
    else
    {
      SWL_LED_OFF(SWL_RED);
      SWL_LED_ON(SWL_GREEN);
    }
    //testing in 7-seg to get values for ch0= an0
    MuxLEDOut16D((unsigned int)A0,0);
    (void)sprintf(buffA0,"CH0: %5.3fV",A0);
    lcdStringXY(0,0,buffA0);

    //testing in 7-seg to get values for ch1=an1
    MuxLEDOut16D((unsigned int)A1,1);
    (void)sprintf(buffA1,"CH1: %5.3fV",A1);
    lcdStringXY(0,1,buffA1);
  }                   
}