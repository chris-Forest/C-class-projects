#include <hidef.h>
#include "derivative.h"
#include "sci0_Lib.h"

unsigned long sci0_Init (unsigned long ulBusClock, unsigned long ulBaudRate)
{
    unsigned int reg=(unsigned int)((ulBusClock/16ul)/ulBaudRate);

    SCI0BDH=(unsigned char)((reg>>8)&0x1F);
    SCI0BDL=(unsigned char)reg;
    //or
    //SCI0BD=reg&0x1fffu;

    SCI0CR1=0x00;
    SCI0CR2=SCI0CR2_TE_MASK|SCI0CR2_RE_MASK;

    return(ulBusClock/16ul)/(SCI0BDL+256*(SCI0BDH&0x1F));
}
int sci0_read (unsigned char * pData)
{
    if(SCI0SR1_RDRF)
    {
        *pData=SCI0DRL;
        return 1;
    }
    return 0;
}

// blocking byte read
unsigned char sci0_Bread (void)
{
    while (!(SCI0SR1_RDRF))
    {
       ;
    }
     return SCI0DRL;
}

// send a null-terminated string over SCI
void sci0_txStr (char const * straddr)
{
    for (; *straddr; ++straddr)
    {
        sci0_txByte(*straddr);
    }    
}
void sci0_txByte (unsigned char data)
{
    while (!SCI0SR1_TDRE)
    {
        ;
    }    
    SCI0DRL=data;
}
void sci0_SetIntFlag (unsigned char flags)
{
    SCI0CR2|=flags;
}
void sci0_ClrIntFlag (unsigned char flags)
{
     SCI0CR2 &=(~flags);
}