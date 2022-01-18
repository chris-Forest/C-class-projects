#include <hidef.h>
#include "derivative.h"
#include "AtoD.h"

//interrupt VectorNumber_Vatd0 void INT_AD0(void);
//(int enableInterrupts)
void AtoDInit(int enableInterrupts)
{
    //ATD0CTL2=0b11000000;

    if(enableInterrupts==1)  //if =1 set bin number to with bit
    {
        //ATD1CTL2_ASCIE=1;   //only this but in bin number below
        ATD0CTL2=0b11000010;//need this?
    } 
    else
    {
        ATD0CTL2=0b11000000;
    }

    ATD0CTL3=0b01000000;
    ATD0CTL4=1;//5.3.2.5
    ATD0CTL5=0b10110000;    
}