/********************************************************************/
// HC12 Program:  7seg with librarys
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       using .h files and .c files display numbers
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
#include "muxled.h"
/********************************************************************/
// Global Variables
/********************************************************************/
 //initalized varibles for loops

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
  MuxLEDOut16B(0xA5FE);//
  MuxLEDOut8(2,0x5F); //
  MuxLEDOutCustom(0,0b11111010);
  MuxLEDOutNormal(1,'3',MuxLED_DP_ON);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {  
      
  }                   
}