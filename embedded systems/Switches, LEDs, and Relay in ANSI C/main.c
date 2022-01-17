#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

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
  PT1AD1 &= 0b00011111;
  DDR1AD1 = 0b11100000;
  ATD1DIEN1 |=0b00011111; 
  PTM &=0x0F;
  DDRM |=0xF0;
  PT1AD1 |= 0b00100000; //turn green led on
  //PTM |= ~0b00010000;      //turn off PTM:4 
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
      if(PT1AD1 & 0b00010000) // if up button is pressed
      {
          PT1AD1 &= ~0b00100000;   //turn green off
          PT1AD1 |= 0b10000000;    //red led turns on
          PTM |= 0b00010000;       //turn on PTM:4
      }
      else if(PT1AD1 & 0b00000100) //if down is pressed
      {
          PT1AD1 &= ~0b10000000;   // turn red led off
          PT1AD1 |= 0b00100000;    //turn green led on 
          PTM &= ~0b00010000;      //turn off PTM:4           
      }
  }                   
}