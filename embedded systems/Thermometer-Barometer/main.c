/********************************************************************/
// HC12 Program:  lab 9 - Thermometer/Barometer
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        chris forest
// Details:       microcontroller board into a simple weather station
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
//#include "muxled.h"
//#include "sw_led.h"
#include "LTC2633.h"
#include "i2c.h"
#include "AtoD.h"
#include"lcd.h"
#include"timer.h"
#include "MPL3115.h"

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  float temp;
  float pressure;
  char buff[16];
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  I2C_Init0(I2CMicro8MHz,I2CBus400,0);
  lcdInit();
  timerinit(7,31250,0,Timer_Pin_Disco);
  MPL3115_Init();
  lcdStringXY(0,0,"curent conditions:");
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(MPL3115_TRdy())
    {
      temp= MPL3115_GetT();
      {
        (void)sprintf(buff,"%0.1fC",temp);
        lcdStringXY(0,2,buff);//err
      }
    }
    if(MPL3115_PRdy())
    {
      pressure=MPL3115_GetP();
      {
        (void)sprintf(buff,"%0.1fKpa",(pressure+7783)/1000);
        lcdStringXY(0,3,buff);//err
      }
    }
  }                   
}