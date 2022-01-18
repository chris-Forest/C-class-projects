/********************************************************************/
// HC12 Program:  ica19 - PWN light control
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       use pwn channels to adjust lcd screen back light 
//                and brightness of micro rrgb leds
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
//#include "muxled.h"
#include "sw_led.h"
#include "lcd.h"
#include "pwm_lib.h"
//#include "timer.h"
#include "misc.h"

void main(void)
{
  unsigned int count=50;
  unsigned int redLED=1;
  unsigned int greenLED=1;
  unsigned int blueLED=1;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  lcdInit();
  //timerinit(7,156250,0,Timer_Pin_Disco);//250ms sleep
  SWL_Init();
  lcdStringXY (0,0,"You light up");
  lcdStringXY (0,1,"my life!");  
  
  //************************************/
  //BacklightInit
  PWMChannelInit(PWME_Channel3,1,0,333);
  PWMChannelProg(PWME_Channel3,100,count);
  PWMChannelON(PWME_Channel3);

  //******************************************************************
  // redLEDInit
  PWMChannelInit(PWME_Channel4,1,2,83);
  PWMChannelProg(PWME_Channel4,200,redLED);
  PWMChannelON(PWME_Channel4);
  // greenLEDInit
  PWMChannelInit(PWME_Channel1,1,2,83);
  PWMChannelProg(PWME_Channel1,200,greenLED);
  PWMChannelON(PWME_Channel1);
  // blueLEDInit
  PWMChannelInit(PWME_Channel0,1,2,83);
  PWMChannelProg(PWME_Channel0,200,blueLED);
  PWMChannelON(PWME_Channel0);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {   
    if(SWL_SW_Pushed(SWL_UP))
    {
      count=PWMDTY3;
      count++;
      if(count>99)
        count=99;
      PWMDTY3=count;
    }
    if(SWL_SW_Pushed(SWL_DOWN))
    {
      count=PWMDTY3;
      count--;
      if(count<1)
        count=1;
      PWMDTY3=count;
    }
    //********************
    if(SWL_SW_Pushed(SWL_LEFT))
    {
      redLED=PWMDTY4;
      redLED+=1;
      if(redLED>50)
        redLED=50;
      PWMDTY4=redLED;
      //PWMChannelProg(PWME_Channel4,200,redLED);
    }
    else
    {
      redLED=PWMDTY4;
      redLED-=1;
      if(redLED<1)
        redLED=1;
      PWMDTY4=redLED;
      //PWMChannelProg(PWME_Channel4,200,redLED);
    }
    
    if(SWL_SW_Pushed(SWL_CTR))
    {
      greenLED+=1;
      if(redLED>50)
        redLED=50;
      PWMChannelProg(PWME_Channel1,200,greenLED);
    }
    else
    {
      greenLED-=1;
      if(redLED<1)
        redLED=1;
      PWMChannelProg(PWME_Channel1,200,greenLED);
    }

    if(SWL_SW_Pushed(SWL_RIGHT))
    {
      blueLED+=1;
      if(redLED>50)
        redLED=50;
      PWMChannelProg(PWME_Channel0,200,blueLED);
    }
    else
    {
      blueLED-=1;
      if(redLED<1)
        redLED=1;
      PWMChannelProg(PWME_Channel0,200,blueLED);
    }
    delay(25);
    //sleep(25);
  }                   
}