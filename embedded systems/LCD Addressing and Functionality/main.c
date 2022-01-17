#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
#include "misc.h"
#include "muxled.h"
#include "sw_led.h"
#include "lcd.h"
/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  int sw_ctrLastState = 0;
  int sw_downLastState = 0;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  lcdInit();
  MuxLEDInit();
  SWL_Init();
  lcdDispControl(1,0);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    delay(250);
    SWL_LED_TOG(SWL_RED);

    {//ctr btn pushed draw the letter ‘A’ at the current cursor position.
      int cursate=SWL_SW_PushedDeb(SWL_CTR);               
      if((cursate!=sw_ctrLastState)&&cursate)
      {
        lcdData('A');
      }        
      sw_ctrLastState=cursate; 
    }
    {//btm btn pushed show your name on the 3rd row, starting at the 2nd postion.
      int cursate=SWL_SW_PushedDeb(SWL_DOWN);               
      if((cursate!=sw_downLastState)&&cursate)
      {        
        lcdStringXY(1,2,"Forest");           
      }        
      sw_downLastState=cursate;  
    }
    {//top btn pushed clear the display.
      if(SWL_SW_Pushed(SWL_UP))
      {
        lcdClear();
      }
    }
    {//right btn pushed move the cursor to the bottom right of the display
      if(SWL_SW_Pushed(SWL_RIGHT))
      {
        lcdAddrXY(19,3);
        lcdDispControl(1,0);
      }
    }
  }                   
}