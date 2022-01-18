#include <hidef.h>      /* common defines and macros */
#include "derivative.h"

typedef enum
{
    PWME_Channel0=0x01,
    PWME_Channel1=0x02,
    PWME_Channel2=0x04,
    PWME_Channel3=0x08,
    PWME_Channel4=0x10,
    PWME_Channel5=0x20,
    PWME_Channel6=0x40,
    PWME_Channel7=0x80
}PWMChannel;

typedef enum
{
    PWM_low=0,
    PWM_high=1
}Polarity;

//Initialize the selected channel
void PWMChannelInit (PWMChannel chan, Polarity pol, unsigned char prclk, unsigned char sclclk);

//turn on/off a PWM channel
void PWMChannelON (PWMChannel chan);
void PWMChannelOff (PWMChannel chan);

//program a PWM channel for period and duty
void PWMChannelProg (PWMChannel chan, unsigned char Period, unsigned char Duty);

// helpers
//void PWMLocalAInit (unsigned char scaleClk);
//void PWMLocalBInit (unsigned char scaleClk);

// note: (Table 8-3)
// chan 0, 1, 4, 5 and clock A
// chan 2, 3, 6, 7 and clock B

// note: with polarity high (1), the channel will cycle high until duty count, then drop low
// if duty is zero, the line will idle low
// if duty = period, the line will idle high

// clock generation for a channel is (per chan A or B): bus [/PCK] => ClockAB [/(2*SCL)] => ClockSAB
// bus / 2^N of PCKX2:PCKX0 => ClockX
// ClockSX = ClockX / (2 * PWMSCLX)
// inits in this library use ClockSX for each channel
// A -> 8MHz / 8 / 2 == 500KHz = 2us/tick (more useful for LEDs)
// B -> 8MHz / 64 / 10 == 12.5KHz = 80us/tick (more useful for speaker)

// wired on board as:
// chan 0 A (PWM Blue Component of RGBLED)
// chan 1 A (PWM Green Component of RGBLED)
// chan 2 B (not assigned)
// chan 3 B (PWM LCD Backlight)
// chan 4 A (PWM Red Component of RGBLED)
// chan 5 A (not assigned)
// chan 6 B (PWM Speaker PWM Output)
// chan 7 B (not assigned)

//PWMPER would be period,
//PRCLK would be prescale,
//SCL would be scaled.