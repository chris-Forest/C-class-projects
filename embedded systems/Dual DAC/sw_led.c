/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/

#include "sw_led.h"
#include "misc.h"

void SWL_Init (void)
{
    PT1AD1 &= 0b00011111;    // turn off all leds starting in known state
    DDR1AD1 = 0b11100000;    // leds are outputs and switches are inputs
    ATD1DIEN1 |=0b00011111;  //digital inputs for switches
}
void SWL_PortjInit(void)
{
    DDRJ&=0b11111100;//set as inputs pjo/pj1- 22.3.2.56 big pink
    PPSJ&=0b11111100; //falling edge for pjo/pj1- 22.3.2.59 big pink
    PIEJ|=0b00000011; //enable inerrupts- 22.3.2.60 big pink
}
// LED functions
// when an led color needs to be on call this method
void SWL_LED_ON (SWL_LEDColour led)
{
    PT1AD1 |= (byte)led;
}
// when an led color needs to be off call this method
void SWL_LED_OFF (SWL_LEDColour led)
{
    PT1AD1 &= ~(byte)led;
}

void SWL_LED_TOG (SWL_LEDColour led)
{
    PT1AD1 ^= (byte)led;
}
int SWL_SW_Pushed (SWL_SwitchPos pos)
{
    return PT1AD1 & pos;
}
int SWL_SW_PushedDeb (SWL_SwitchPos pos)
{
    int curstate=0,sample=0;

    do
    {
        sample=SWL_SW_Pushed(pos);
        delay(5);
        curstate=SWL_SW_Pushed(pos);
    } while (sample!=curstate);  
    return curstate;  
}
int SWL_SW_Transition (SWL_SwitchPos pos)
{
    //temporary variable for the state of the switch 
    char temp = 0; 

    //initialize states    
    static char upState = 0;
    static char downState = 0;
    static char leftState = 0;
    static char rightState = 0;
    static char ctrState = 0;

    //get current state
    char current = (char)SWL_SW_PushedDeb(pos);

    //check for state change
    switch (pos)
    {
        case SWL_UP:
        //state is on and state is currently off
        if (current && (upState != current))
        {
            //transition
            temp = 1;
        }
        //save the state
        upState = current;
        break;

        case SWL_DOWN:
        //state is on and state is currently off
        if (current && (downState != current))
        {
            //transition
            temp = 1;
        }
        //save the state
        downState = current;
        break;
    
        case SWL_LEFT:
        //state is on and state is currently off
        if (current && (leftState != current))
        {
            //transition
            temp = 1;
        }
        //save the state
        leftState = current;
        break;
    
        case SWL_RIGHT:
        //state is on and state is currently off
        if (current && (rightState != current))
        {
            //transition
            temp = 1;
        }
        //save the state
        rightState = current;
        break;

        case SWL_CTR:
        //state is on and state is currently off
        if (current && (ctrState != current))
        {
            //transition
            temp = 1;
        }
        //save the state
        ctrState = current;
        break;
    }
    return temp;
}
int SWL_SW_Any (void)
{
    return PT1AD1 &0b00011111;
}
void DelayTimer1ms(unsigned int limit) //1ms delay
{
  while (limit > 0)
  {
    asm LDX #2667; //26667 x 3 cycles x 125 ns = 1ms
    asm DBNE X,*;
    limit--;
  }
}