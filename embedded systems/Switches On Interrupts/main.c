/********************************************************************/
// HC12 Program:  ica13 -  more interrupts
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       portj inteerupts count up and down on 7-seg display
                  
// Date:          november 3 2020

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
#include "misc.h"
#include "muxled.h"
//#include "sw_led.h"
#include "lcd.h"
#include "sci0_Lib.h"

unsigned int counter=0;
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
  MuxLEDInit();
  DDRJ&=0b11111100;//set as inputs pjo/pj1- 22.3.2.56 big pink
  PPSJ&=0b11111100; //falling edge for pjo/pj1- 22.3.2.59 big pink
  PIEJ|=0b00000011; //enable inerrupts- 22.3.2.60 big pink

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    asm WAI;
    MuxLEDOut16D(counter,0);
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

interrupt VectorNumber_Vportj void intj(void)
{
  //if pf0 press/releasewd count up
  if(PIFJ&0b00000001)
  {
    counter++;
    if(counter>9999)counter=0;
    PIFJ |=0b00000001; //interrupt acknologed
  }

  //if pj1 pressed/released count down
  if(PIFJ&0b00000010)
  {
    counter--;
    if(counter<=0)counter=9999;
    PIFJ |=0b000000010; //interrupt acknologed
  }
}