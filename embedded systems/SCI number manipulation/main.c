/********************************************************************/
// HC12 Program:  YourProg - MiniExplanation
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        This B. You
// Details:       A more detailed explanation of the program is entered here
                  
// Date:          Date Created
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
#include <stdio.h>
#include <math.h>
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
//#include "misc.h"
//#include "muxled.h"
//#include "sw_led.h"
//#include "lcd.h"
#include "sci0_Lib.h"

/********************************************************************/
// Main Entry
/********************************************************************/

void main(void)
{
  char data;
  char data2;
  char buuff[3];
  char choice;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  (void) sci0_Init(8000000,9600);
  // reset attributes, clear screen  
  //sci0_txStr ("\x1b[0m\x1b[2J"); 
  sci0_txStr ("\x1b[47m\x1b[2J"); 
  sci0_txStr("\x1b[0;30H\x1b[35mpositive adding");//was 5
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {    
    do 
    {
      sci0_txStr("\x1b[3;35H\x1b[30mA = ");
      do
      {
        data=sci0_Bread();// blocking read and waits fir keystrock
      }
      while(!(data>='0'&&data<='9'));

      //show in putty
      sci0_txByte(data);//echo back
      data-=0x30; 

      //sci0_txStr("\x1b[3;35H  ");//spaces to clear specfic items
      sci0_txStr("\x1b[4;35HB = ");
      do
      {
        data2=sci0_Bread();// blocking read and waits fir keystrock
      }
      while(!(data2>='0'&&data2<='9'));

      //show in putty
      sci0_txByte(data2);//echo back
      data2-=0x30;
    
      sci0_txStr("\x1b[5;31HA + B = ");
      (void)sprintf(buuff,"%d",data+data2);
      sci0_txStr(buuff);

      sci0_txStr("\x1b[7;30HAgain(y/n)");
      choice=sci0_Bread();
      if(choice=='N'||choice=='n')
      {
        sci0_txStr("\x1b[9;30H\x1b[32mGood bye!");
      }
      // if(choice=='Y'||choice=='y')
      // {
      //   sci0_txStr("\x1b[3;35H    ");
      // }
    }
    while(choice!='y'||choice!='Y'||choice!='n'||choice!='N');    
  }               
}