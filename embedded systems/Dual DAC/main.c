#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
#include "misc.h"
//#include "muxled.h"
#include "sw_led.h"
#include "LTC2633.h"
#include "i2c.h"
#include "timer.h"

/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int val=0;

/********************************************************************/
// Main Entry
/********************************************************************/
// void main(void)
// {  
//   // main entry point
//   _DISABLE_COP();
//   EnableInterrupts;
  
//   /********************************************************************/
//   // initializations
//   /********************************************************************/
//   I2C_Init0(I2CMicro8MHz,I2CBus400,0);
//   SWL_Init();
//   //timerinit(7,31250,1,Timer_Pin_Disco);
//   /********************************************************************/
//   // main program loop
//   /********************************************************************/
//   //(void)LTC2633_WriteChan(2500,0,LTC2633_CHAN_A);
//   //4 vals needed 0V, 0x0fff(max)?,1V,2V
//   for (;;)
//   {
//     //1v
//     if(SWL_SW_Pushed(SWL_UP))
//     {
//       (void)LTC2633_WriteChan(1000,0,LTC2633_CHAN_A);
//     }
//     //2v
//     if(SWL_SW_Pushed(SWL_LEFT))
//     {
//       (void)LTC2633_WriteChan(2000,0,LTC2633_CHAN_A);
//     }
//     //0v
//     if(SWL_SW_Pushed(SWL_RIGHT))
//     {
//       (void)LTC2633_WriteChan(0,0,LTC2633_CHAN_A);
//     }
//     //4.095v
//     if(SWL_SW_Pushed(SWL_DOWN))
//     {
//       (void)LTC2633_WriteChan(0x0fff,0,LTC2633_CHAN_A);
//     }
//   }                   
// }

void main(void)
{  
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  I2C_Init0(I2CMicro8MHz,I2CBus400,0);
  SWL_Init();
  //timerinit(7,31250,1,Timer_Pin_Disco);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  //(void)LTC2633_WriteChan(2500,0,LTC2633_CHAN_A);
  //4 vals needed 0V, 0x0fff(max)?,1V,2V
  for (;;)
  {
    delay(10);
    if(SWL_SW_Pushed(SWL_UP))
    {
      val++;
      if(val>4095)
        val=0;
      (void)LTC2633_WriteChan(val,0,LTC2633_CHAN_A);
    }

    if(SWL_SW_Pushed(SWL_DOWN))
    {
      val--;
      if(val<=0)
        val=4095;
      (void)LTC2633_WriteChan(val,0,LTC2633_CHAN_A);
    }
  }                   
}