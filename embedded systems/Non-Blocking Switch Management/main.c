/********************************************************************/
// HC12 Program:  lab 3 - switch management
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       use a non-blocking routines to help switch presses while another loop operates
                  
// Date:          october 6 2020

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
#include "misc.h"
#include "muxled.h"
#include "sw_led.h"
/********************************************************************/
// Main Entry
/********************************************************************/
//int SWL_SW_PushedDeb(SWL_SwitchPos pos);
//int trDW(unsigned int count);
void main(void)
{
  unsigned int count = 0;
  unsigned int UPcount = 0;
  int sw_upLastState = 0;
  int sw_downLastState = 0;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  SWL_Init();
  MuxLEDInit ();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    int i=0;    
    //counter and displayed on top line of 7 seg
    for (i = 0; i < 100; i++)
    {        
      // int cursate,sample;
      // do
      // {
      //   sample=SWL_SW_Pushed(SWL_UP);
      //   delay(2);
      //   cursate=SWL_SW_Pushed(SWL_UP);
      // } while (sample!=cursate);
         
      {
        int cursate=SWL_SW_PushedDeb(SWL_UP);
        //both on bottm line
        if((cursate!=sw_upLastState)&&cursate)//count up
        {
          MuxLEDOut16D(UPcount++,1);          
        }
        sw_upLastState=cursate;  
        if(UPcount>9999){UPcount=0;}       
      }
      
      { 
        // int cursate,sample;
        // do
        // {
        //   sample=SWL_SW_Pushed(SWL_DOWN);
        //   delay(2);
        //   cursate=SWL_SW_Pushed(SWL_DOWN);
        // } while (sample!=cursate);
        
        int cursate=SWL_SW_PushedDeb(SWL_DOWN);
               
        if((cursate!=sw_downLastState)&&cursate)//count down
        {
          if(UPcount<=0){UPcount=9999;}//roll under
          MuxLEDOut16D(UPcount--,1);          
        }        
        sw_downLastState=cursate;        
      }
      
      //clear both displays
      if(SWL_SW_Pushed(SWL_CTR))
      {
        count=0;
        UPcount=0;
      }
      MuxLEDOut16D(count,0);
      MuxLEDOut16D(UPcount,1);
    }  
    count++;
    MuxLEDOut16D(count,0);         
  }                   
}