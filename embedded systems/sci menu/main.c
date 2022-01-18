/********************************************************************/
// HC12 Program:  lab05 - sci menus and lcd sreen
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        Chris Forest
// Details:       sci menu that branches and displays a message on lcd screen
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
#include <stdio.h>
/********************************************************************/
// Library includes
/********************************************************************/

// your includes go here
//#include "misc.h"
//#include "muxled.h"
#include "sw_led.h"
#include "lcd.h"
#include "sci0_Lib.h"

/********************************************************************/
// Main Entry
/********************************************************************/
void MainMenu(void);
void LEDMenu(void);
void LCDMenu(void);
void Story(void);
void main(void)
{
  char mainMenu;
  char LED_Menu;
  char LCD_Menu;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  SWL_Init();
  lcdInit();
  (void) sci0_Init(8000000,9600);
  // set background color, clear screen  
  sci0_txStr ("\x1b[47m\x1b[2J"); 

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    MainMenu();
    do
    {
      mainMenu=sci0_Bread();
//****LED menu***************************      
      if(mainMenu=='1')
      {
        //led menu
        LEDMenu();
        do
        {
          LED_Menu=sci0_Bread();
          //red on
          if(LED_Menu=='1')
          {
            SWL_LED_ON(SWL_RED);
          }
          if(LED_Menu=='2')
          {
            SWL_LED_ON(SWL_YELLOW);
          }
          if(LED_Menu=='3')
          {
            SWL_LED_ON(SWL_GREEN);
          }
          if(LED_Menu=='4')
          {
            SWL_LED_OFF(SWL_RED);
          }
          if(LED_Menu=='5')
          {
            SWL_LED_OFF(SWL_YELLOW);
          }
          if(LED_Menu=='6')
          {
            SWL_LED_OFF(SWL_GREEN);
          }
          //all on
          if(LED_Menu=='7')
          {
            SWL_LED_ON(SWL_RED);
            SWL_LED_ON(SWL_YELLOW);
            SWL_LED_ON(SWL_GREEN);
          }
          //all off
          if(LED_Menu=='8')
          {
            SWL_LED_OFF(SWL_RED);
            SWL_LED_OFF(SWL_YELLOW);
            SWL_LED_OFF(SWL_GREEN);
          }
          //issuse here!!
          if(LED_Menu=='M'||LED_Menu=='m')
          {
            sci0_txStr ("\x1b[2J"); 
            MainMenu();
          }
        }
        while(!(LED_Menu=='M'||LED_Menu=='m'));
        sci0_txByte(LED_Menu);
        LED_Menu-=0x30;  
        //sci0_txStr ("\x1b[2J"); 
      }
//****//lcd menu*********************************************************
      if(mainMenu=='2')
      {
        LCDMenu();
        do
        {
          LCD_Menu=sci0_Bread();
          //clear lcd
          if(LCD_Menu=='1')
          {
            lcdClear();
          }
          //display story
          if(LCD_Menu=='2')
          {
            Story();            
          }
          if(LCD_Menu=='M'||LCD_Menu=='m')
          {
            sci0_txStr ("\x1b[2J"); 
            MainMenu();
          }
        }
        while(!(LCD_Menu=='M'||LCD_Menu=='m'));
        sci0_txByte(LCD_Menu);
        LCD_Menu-=0x30;
        //sci0_txStr ("\x1b[2J"); 
      }
//**************************************************************************      
    }
    while(!(mainMenu>='0'&&mainMenu<='3'));
    sci0_txByte(mainMenu);
    mainMenu-=0x30;
    //sci0_txStr ("\x1b[2J");  
  }                   
}
/********************************************************************/
// Functions
/********************************************************************/
void MainMenu(void)
{
  sci0_txStr ("\x1b[30m\x1b[0;0HMain menu:\r\n\r\n");
  sci0_txStr ("   1. LED's\r\n");
  sci0_txStr ("   2. LCD\r\n"); 
  sci0_txStr ("   Choice: ");
}
void LEDMenu(void)
{
  sci0_txStr ("\x1b[30m\x1b[0;0HLED menu: \r\n\r\n");
  sci0_txStr ("   1. Red On\r\n");
  sci0_txStr ("   2. Yellow On\r\n"); 
  sci0_txStr ("   3. Green on\r\n"); 
  sci0_txStr ("   4. Red off\r\n"); 
  sci0_txStr ("   5. Yellow off\r\n"); 
  sci0_txStr ("   6. Green off\r\n"); 
  sci0_txStr ("   7. All On\r\n"); 
  sci0_txStr ("   8. All Off\r\n"); 
  sci0_txStr ("   M. Main Menu\r\n"); 
  sci0_txStr ("   Choice: ");  
}
void LCDMenu(void)
{
  sci0_txStr ("\x1b[30m\x1b[0;0HLCD menu: \r\n\r\n");
  sci0_txStr ("   1. Clear LCD Screen\r\n");
  sci0_txStr ("   2. Display LCD Story\r\n"); 
  sci0_txStr ("   M. Main Menu\r\n"); 
  sci0_txStr ("   Choice: "); 
}
void Story(void)
{
  lcdStringXY(0,0,"Once upon a time, ");
  lcdStringXY(0,1,"there were 3 bears, ");
  lcdStringXY(0,2,"who lived in a house");
  lcdStringXY(0,3,"in the big woods.");
}