/********************************************************************/
//consists of 4 different progrms involving Switch Management and 7 seg display
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

//part1
// void main(void)
// {
//   unsigned int count = 0;
//   // main entry point
//   _DISABLE_COP();
//   EnableInterrupts;  
//   /********************************************************************/
//   // initializations
//   /********************************************************************/
//   SWL_Init();
//   MuxLEDInit ();  
//   /********************************************************************/
//   // main program loop
//   /********************************************************************/
//   for (;;)
//   {     
//     if(SWL_SW_Pushed(SWL_LEFT))
//     {
//       count++;      
//       SWL_LED_ON(SWL_RED);
//     }
//     else
//     {
//       SWL_LED_OFF(SWL_RED);
//     }
//     if(count>9999)
//       count=0;
//     MuxLEDOut16D(count,0);

//     if(SWL_SW_Pushed(SWL_CTR))
//     {
//       SWL_LED_ON(SWL_YELLOW);
//     }
//     else
//     {
//       SWL_LED_OFF(SWL_YELLOW);
//     }     
      
//     if(SWL_SW_Pushed(SWL_RIGHT))
//     {
//       SWL_LED_ON(SWL_GREEN);
//     }
//     else
//     {
//       SWL_LED_OFF(SWL_GREEN);
//     }      
//   }                   
// }

//part 2
// void main(void)
// {
//   int sw_ctrLastState = 0;
//   // main entry point
//   _DISABLE_COP();
//   EnableInterrupts;
  
//   /********************************************************************/
//   // initializations
//   /********************************************************************/
//   SWL_Init();
//   MuxLEDInit ();
//   SWL_LED_ON(SWL_GREEN);
//   SWL_LED_OFF(SWL_RED);
//   /********************************************************************/
//   // main program loop
//   /********************************************************************/
//   for (;;)
//   { 
//     int cursate=SWL_SW_Pushed(SWL_LEFT);
//     if((cursate!=sw_ctrLastState)&&cursate)
//     {
//       SWL_LED_TOG(SWL_GREEN);
//       SWL_LED_TOG(SWL_RED);
//     }
//     sw_ctrLastState=cursate;
//   }                   
// }

//part 3
// void main(void)
// {
//   unsigned int count = 0;
//   int sw_ctrLastState = 0;
//   // main entry point
//   _DISABLE_COP();
//   EnableInterrupts;
  
//   /********************************************************************/
//   // initializations
//   /********************************************************************/
//   SWL_Init();
//   MuxLEDInit ();
//   /********************************************************************/
//   // main program loop
//   /********************************************************************/
//   for (;;)
//   {        
//     {
//       // if left is pushed count in hex
//       int cursate=SWL_SW_Pushed(SWL_LEFT);//help with transitioning
//       if((cursate!=sw_ctrLastState)&&cursate)
//       {
//         //block from other buttons being pressed
//         while (SWL_SW_Pushed(SWL_LEFT))
//         {
//         MuxLEDOut16A (count++);
//         }
//       }      
//       sw_ctrLastState=cursate;
//     }     
//     //reset conter if mid buton is pressed
//     if(SWL_SW_Pushed(SWL_CTR))
//     {
//       count=0;      
//     }
//     MuxLEDOut16A (count);
//   }                   
// }

//part 4
void main(void)
{
  unsigned int count = 0;
  int sw_ctrLastState = 0;
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
    {
      // if left is pushed count in hex
      int cursate=SWL_SW_Pushed(SWL_LEFT);//help with transitioning
      if((cursate!=sw_ctrLastState)&&cursate) 
      {
        //block from other buttons being pressed
        while (SWL_SW_Pushed(SWL_LEFT)){}
        count++; 
        MuxLEDOut16A (count);
      }      
      sw_ctrLastState=cursate;
    }     
    //reset conter if mid buton is pressed
    if(SWL_SW_Pushed(SWL_CTR))
    {
      count=0;      
    }
    MuxLEDOut16A (count);
  }                   
}