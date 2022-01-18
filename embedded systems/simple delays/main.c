/********************************************************************/
// HC12 Program:  ica14 -  simple delays
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       change sleep time with a button push
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

//unsigned int counter=0;
/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  unsigned int counter=0;  
  int curState=0;
  int sw_LastState = 0;
  int sw_nextState=0;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  MuxLEDInit();
  timerinit(7,6250,0,0,Timer_Pin_Disco);//0b00000111
  //timerinit(7);//0b00000111
  SWL_Init();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    MuxLEDOut16D(counter,0);
    sleep(100);//100ms sleep reped as 16us tick rate
    counter++;   
    if(counter>9999)counter=0;

    curState=SWL_SW_Pushed(SWL_CTR);
    if((curState!=sw_LastState)&&curState)
    {      
      //timerinit(1);//125ns
      if(TSCR2>=0b00000111)//0b00000001
      {
        timerinit(1,6250,0,0,Timer_Pin_Disco);//125ns
        //timerinit(1);//0b00000111
      }
      else //0b00000111
      {
        timerinit(7,6250,0,0,Timer_Pin_Disco);//16us 
        //timerinit(7);//0b00000111
      }
    }
    sw_LastState=curState;    
  }                   
}