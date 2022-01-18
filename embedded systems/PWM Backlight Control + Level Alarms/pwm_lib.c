#include <hidef.h>      /* common defines and macros */
#include "derivative.h"
#include "pwm_lib.h"

//Initialize the selected channel
void PWMChannelInit (PWMChannel chan, Polarity pol, unsigned char prclk, unsigned char sclclk)
{
    //prclk value cant be above 7
    if (prclk > 7)
        prclk = 7;

    //Group A
    if (chan == PWME_Channel0 || chan == PWME_Channel1 || chan == PWME_Channel4 || chan == PWME_Channel5)
    {
        //set clock to prclk value
        PWMPRCLK &= 0b11111000;
        PWMPRCLK |= prclk;

        //set Clock SA to divide by 8
        PWMSCLA = sclclk;

        //select ClockSA for channel
        PWMCLK |= chan;

        //set polarity
        if (pol)
            PWMPOL |= chan;
        else
            PWMPOL &= ~chan;
    }
    //group B
    else
    {
        //shift prclk left 4
        prclk = prclk << 4;

        //set clock to prclk value
        PWMPRCLK &= 0b11111000;
        PWMPRCLK |= prclk;

        //set Clock SB to divide by #
        PWMSCLB = sclclk;

        //select ClockSB for channel
        PWMCLK |= chan;

        //set polarity
        if (pol)
            PWMPOL |= chan;
        else
            PWMPOL &= ~chan;
    }   
}

//turn on/off a PWM channel
void PWMChannelON (PWMChannel chan)
{
    PWME |= chan;
}
void PWMChannelOff (PWMChannel chan)
{
    PWME &= ~chan;
}

//program a PWM channel for period and duty
void PWMChannelProg (PWMChannel chan, unsigned char Period, unsigned char Duty)
{
    if (chan == PWME_Channel0)
    {
        PWMPER0 = Period;
        PWMDTY0 = Duty;
    }

    if (chan == PWME_Channel1)
    {
        PWMPER1 = Period;
        PWMDTY1 = Duty;
    }

    if (chan == PWME_Channel2)
    {
        PWMPER2 = Period;
        PWMDTY2 = Duty;
    }

    if (chan == PWME_Channel3)
    {
        PWMPER3 = Period;
        PWMDTY3 = Duty;
    }

    if (chan == PWME_Channel4)
    {
        PWMPER4 = Period;
        PWMDTY4 = Duty;
    }

    if (chan == PWME_Channel5)
    {
        PWMPER5 = Period;
        PWMDTY5 = Duty;
    }

    if (chan == PWME_Channel6)
    {
        PWMPER6 = Period;
        PWMDTY6 = Duty;
    }

    if (chan == PWME_Channel7)
    {
        PWMPER7 = Period;
        PWMDTY7 = Duty;
    }
}