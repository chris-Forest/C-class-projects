/********************************************************************/
// HC12 Program:  ica16 - pit
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        chris forest
// Details:       timer stuff?
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
#include <stdio.h>
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
//#include "misc.h"
#include "muxled.h"
#include "sw_led.h"
#include "timer.h"

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  unsigned int event=0;
  unsigned int startTime=0;
  unsigned int capTimes [50]={0};
  unsigned int capindex=0;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  SWL_Init();
  MuxLEDInit();
  //• enabling the PIT interrupt for channel 0 (13.3.0.5)
  //PITINTE_PINTE0=1;
  PITINTE=0b00000001;// 0r

  //• enabling channel 0 (13.3.0.3)
  PITCE=0b00000001;//or
  //PITCE_PCE0=1;

  //• setting PITMTLD0 and PITLD0 to configure the timeout period
  PITMTLD0=255;//13.3.0.7
  PITLD0=77;

  //• enabling the PIT module (13.3.0.1)
  //PITCFLMT_PITE = 1;//or
  PITCFLMT=0b10100000;
  //stop and test here

  //Initialize the timer for 16us ticks (max prescale).
  timerinit(7,0,0,Timer_Pin_Disco);

  //• Configure channel 0 as an input capture (7.3.2.1)
  TIOS_IOS0=0;

  //• Configure channel 0 for rising edge capture (7.3.2.9)
  TCTL4_EDG0B=0;
  TCTL4_EDG0A=1;

  //• Clear the pending flag for channel 0 (as usual) (7.3.2.12)
  //in inint function call

  //• Save TCNT to an unsigned int variable as the “start time”
  startTime=TCNT;

  //**************************************************************
  //ch1,no pin oc
  TIOS_IOS1=1;//output compare
  TC1=(unsigned int)(TCNT+62500);
  TFLG1_C1F=1;//claer flag
  TIE_C1I=1;

  //accumulator
  PACTL_PAEN=1;//enabled
  PACTL_PEDGE=1;//risding edges
  PACN32=0;//clar count

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {    
    //poll input capture event on ch0
    if(TFLG1_C0F)
    {
      //grab time
      event=TC0;

      //save dsiplacment
      capTimes[capindex]=(event-startTime)*16;

      //clar flag
      TFLG1=TFLG1_C0F_MASK;

      //save start time
      startTime=event;

      //have 50 sample?
      if(++capindex==50)
      {
        //reset
        capindex=0;
        SWL_LED_TOG(SWL_YELLOW);

        //calc avg
        {
          int i=0;
          long sum=0;
          for (size_t i = 0; i < 50; i++)
          {
            sum+=capTimes[i];
          }
          sum/=50;
          MuxLEDOut16D((unsigned int)sum,0);
        }
      }
    }    
  }                   
}

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vpit0 void PITInt(void)
{
  PITTF=PITTF_PTF0_MASK;
  SWL_LED_TOG(SWL_RED);
}
interrupt VectorNumber_Vtimch1 void IOC1 (void)
{
  TFLG1=TFLG1_C1F_MASK;

  TC1=(unsigned int)(TC1+62500);

  SWL_LED_TOG(SWL_GREEN);

  MuxLEDOut16D(PACN32,1);

  PACN32=0;
}