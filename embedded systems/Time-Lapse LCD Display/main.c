#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
#include "misc.h"
#include "sw_led.h"
#include "lcd.h"

/********************************************************************/
// Local Prototypes
/********************************************************************/
void lcdStringDelay (char const * straddr);
/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  lcdInit();
  SWL_Init();
  lcdStringXY(0,0,"Press Any Button:");
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {        
    //button press
    if(SWL_SW_Any())
    {
      lcdClear();
      lcdStringDelay("A ");
      lcdStringDelay("long ");
      lcdStringDelay("Time ");
      lcdStringDelay("Ago ");
      lcdStringDelay("in "); 
      lcdStringDelay("a ");     
      //second lcd line
      lcdAddrXY(0,1);
      lcdStringDelay("Galaxy ");
      lcdStringDelay("far, ");
      lcdStringDelay("far ");
      lcdStringDelay("away");
      lcdStringXY(0,3,"Press Any Button:"); 
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void lcdStringDelay (char const * straddr)
{
  while (*straddr!=0)
  {
    delay(150);//to be 150
    lcdData(*straddr);
    straddr++;    
  }
}
