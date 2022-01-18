/********************************************************************/
// HC12 Program:  lab4 - ascii manipulation
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        chris forest
// Details:       convert a string to upper/lowercase with no numbers and
//                display number in string as a total

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
#include <stdlib.h>
#include <stdio.h>
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
#include "misc.h"
//#include "muxled.h"
//#include "sw_led.h"
#include "lcd.h"

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  char String[]="This3iS5a4sTRING!";
  //char String[]="1";
  char words[18];
  int i=0;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  lcdInit(); 
  {
    for (i = 0; i < 18; i++)
    {
      if(String[i]>='0'&&String[i]<='9')
      {
        //action replace numbers with spaces in new string
        words[i]=' ';
      }
      else
      {
        words[i]=upper(String[i]);
      }
    }
    words[17]=0;
    lcdStringXY(0,0,words);
  }
  
  {
    for ( i = 0; i < 18; i++)
    {
      if(String[i]>='0'&&String[i]<='9')
      {
        //action replace numbers with spaces in new string
        words[i]=' ';
      }
      else
      {
        words[i]=lower(String[i]);
      }
    }
    words[17]=0;
    lcdStringXY(0,1,words);
  } 

  {
    int total=0;
    char buff[20];
    int i=0;
    //numbers hex
    for (i = 0; i < 17; i++)
    {
      if(String[i]>='0'&&String[i]<='9')
      {
        //action count just numbers numbers with spaces in new string
        total += String[i]-48;
      }
      //sprintf here hex 
      (void)sprintf(buff,"0x%02X",total);
    }
    lcdStringXY(0,2,buff);
  } 

  {    
    int i=0;
    int total=0;
    char buff[20];
    //numbers decimal
    for (i = 0; i < 17; i++)
    {
      if(String[i]>='0'&&String[i]<='9')
      {
        //action replace numbers with spaces in new string
        total += String[i]-48;
      }
      //sprintf here dec 
      (void)sprintf(buff,"%d",total);
    }  
    lcdStringXY(0,3,buff);
  }
  
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {

  }                   
}
