#include <hidef.h>      /* common defines and macros */
#include "derivative.h"
#include "timer.h"
#include <math.h>

// typedef enum TimerPinAction
// {
//   Timer_Pin_Disco = 0,
//   Timer_Pin_Toggle = 1,
//   Timer_Pin_Clear = 2,
//   Timer_Pin_Set = 3
// } TimerPinAction;

// timer general (uses OC0 - toggle pin)
// prescale value as 2^N (0 - 7 as argument = bus / (1 to 128)) in general, 7 would be used (div by 128)
// uiOffset is initial offset from TCNT
// enableInt is flag for enabling interrupts on OC0
// void TimerInit (unsigned long ulBusClock, unsigned char prescale, unsigned int uiOffset, int enableInt, TimerPinAction pinAction)
// {
// }

//void TimerInit (unsigned long ulBusClock, unsigned char prescale, unsigned int uiOffset, int enableInt, TimerPinAction pinAction)
void timerinit(unsigned char prescale, unsigned int uiOffset, int enableInt, TimerPinAction pinAction)
{
    //enable timer
    TSCR1_TEN=1;

    //set prescalke to clock/128-> 8MHz/128=freq of 62.5kHz->1/62.5kHz= 16us
    // setup a bus/128 prescale, free-run counter, no interrupts (7.3.2.11

    //TSCR2 |=0b00000111;// ok for resting not for cllaing laeter on
    //set as varaiblr

    //TSCR2 =prescale;// better to change timer prescale 
    //if check for 0-7
    if(prescale<8)
        TSCR2 =prescale;//
    else
    {
        TSCR2 =0b00000111;
    }    

    //channel 0 to output compare (7.3.2.1)
    TIOS_IOS0=1;

    //(7.3.2.8) configure channel 0 to toggle pin 9 on successful compare
    TCTL2 &=0b11111100;//clear
    TCTL2 |=pinAction;

    //(7.3.2.10) enable interrupts for channel 0
    TIE_C0I=enableInt;//enableInt

    //(7.3.2.12) clear an interrupt from channel 0, if pending
    if(TFLG1_C0F)
        TFLG1_C0F=1;  

    TC0=TCNT+uiOffset;//16us  +offset
}

// blocking delay for x ms - requires previous InitTimer call
// requires bus/128 in InitTimer call
// range is 1 to 1048ms, uses OC6 (no pin action)
void sleep (float ms)
{
    float offset=0;

    //figure out timer tick/ms 1 tick=16us when 8MHz/128 prescale
    //x#ms/tick rate
    //math in here to get rate
    offset=((ms/1000)/0.000016);//add val to change prescale?
    if(offset>65535)
        offset=65535;
    //(7.3.2.14 + 7.3.2.5) arm channel 0 to trigger an event 10ms from TCNT (10ms from now)    
    //8mHz/128=16us->event 10ms from now->10ms/16us=625 offset

    //alarm for flag
    while (!TFLG1_C0F)
        ;
    
    //while loop -pole versin   
    //ack flag
    TFLG1_C0F=1;
    //rearm
    //+6250 for 100ms
    //TC0+=625;
    TC0+=(int)offset;
}