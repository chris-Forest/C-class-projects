/********************************************************************/
// HC12 Program:  lab 8 - AtoD to DAC
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       take AtoD volt convert to dac val/volt
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
//#include "sw_led.h"
#include "LTC2633.h"
#include "i2c.h"
#include "AtoD.h"
#include"lcd.h"
#include"timer.h"

// Main Entry
/********************************************************************/
void main(void)
{
  float A0;
  unsigned int result=0;
  char buffA0[15];//for n.nnn V format
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  I2C_Init0(I2CMicro8MHz,I2CBus400,0);
  AtoDInit(0);//set up for no minyerrputs , poll version
  lcdInit();
  MuxLEDInit();
  timerinit(6,125,1,Timer_Pin_Disco);//1ms sleep
  /********************************************************************/
  // main program loop
  /********************************************************************/
  //(void)LTC2633_WriteChan(2500,0,LTC2633_CHAN_A);
  for (;;)
  {    
    asm wai;
    if(ATD0STAT0_SCF)
    {
      result=ATD0DR0;
      //do theese represent the pins we are using?
      A0=ATD0DR0*0.005;//*5mV
    } 
    MuxLEDOut16D((unsigned int)A0,0);
    (void)sprintf(buffA0,"CH0: %.3fV",A0);
    lcdStringXY(0,0,buffA0); 

    A0/=5; //to normalize to dac
    A0*=4095;//*max dac v to convert to dac need to de dec?
    
    //see value on dac
    (void)LTC2633_WriteChan(A0,0,LTC2633_CHAN_A);

    MuxLEDOut16D((unsigned int)A0,1);
    (void)sprintf(buffA0,"DAC: %.3fV",A0/1000);
    lcdStringXY(0,1,buffA0); 
  }                   
}

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vtimch0 IOC0(void)
{
  TFLG1=TFLG1_C0F_MASK;

  //re-arm 1ms delay
  TC0+=125;
}