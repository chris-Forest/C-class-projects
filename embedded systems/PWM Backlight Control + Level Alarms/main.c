/********************************************************************/
// HC12 Program:  ica18 - PWN channels
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       use pwn channels to adjust lcd screen back light 
//                and make a noise when over or under a volt range
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
//#include "misc.h"
//#include "muxled.h"
//#include "sw_led.h"
#include"lcd.h"
#include "AtoD.h"
#include "pwm_lib.h"

void lowTone(void);
void highTone(void);

void main(void)
{
  float A0;
  unsigned int result=0;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  AtoDInit(0);//set up for no interrputs , poll version
  lcdInit();
  
  PWMPRCLK&=0b10001111;//clear a channel *(clk) prescale clock*
  PWMPRCLK|=0b00010000;//2^1=2 for clock b

  // set sb divide by 8 *scaled clock (SCL)*
  PWMSCLB=4;// 2*(4x2)=16

  //set clock sb to channel being used
  PWMCLK_PCLK3=1;

  //plaority
  PWMPOL_PPOL3=1;

  //period
  PWMPER3=100;

  //enable channel
  PWME_PWME3=1;
 
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {   
    //for polling
    if(ATD0STAT0_SCF)
    {
      result=ATD0DR0;

      //sets voltage is pin 67
      A0=ATD0DR0*0.005;//*5mV 

      //duty
      PWMDTY3=(A0/5)*100;
    } 

    //low volts
    if(A0<0.5)
    {
      //alarm tone at 261.63Hz
      lowTone();      
    }
    else
    {
      //disable ch6
      PWME_PWME6=0;
      //no tone normal back light operation
      PWME_PWME3=1;
    }
    //high volts
    if(A0>4.5)
    {
      //alarm tone  698.46Hz
      highTone();
    }
    else
    {
      //disable ch6
      PWME_PWME6=0;
      PWME_PWME3=1;
    }
  }                   
}
/********************************************************************/
// Functions
/********************************************************************/
void lowTone(void)
{
  //polarity,clear channal for use of ch b, set 2^n value,set which channel to be used
  PWMChannelInit(1,0b10001111,0b00010000,0b01000000);
  PWMLocalBInit(40);//set sb to 40
  PWMChannelProg(PWME_Channel6,190,80);
  PWMChannelON(PWME_Channel6);

  // PWMPRCLK&=0b10001111;//clear a channel *(clk) prescale clock*
  // PWMPRCLK|=0b00010000;//2^1=2 for clock b

  // // set sb divide by 80 *scaled clock (SCL)*
  // PWMSCLB=40;// 2*(40x2)=160

  // //set clock sb to channel being used
  // PWMCLK_PCLK6=1;//part b

  // //polarity
  // PWMPOL_PPOL6=1;//part b

  // //period
  // PWMPER6=190;
  // //duty
  // PWMDTY6=80;

  // //enable channel
  // PWME_PWME6=1;
}

void highTone(void)
{
  PWMPRCLK&=0b10001111;//clear a channel *(clk) prescale clock*
  PWMPRCLK|=0b00010000;//2^1=2 for clock b

   // set sb divide by 80 *scaled clock (SCL)*
  PWMSCLB=32;// 2*(32x2)=128

  //set clock sb to channel being used
  PWMCLK_PCLK6=1;//part b

  //polarity
  PWMPOL_PPOL6=1;//part b

  //period
  PWMPER6=90;
  //duty
  PWMDTY6=45;

  //enable channel
  PWME_PWME6=1;
}