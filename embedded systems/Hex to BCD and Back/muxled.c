/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
#include "muxled.h"

// setup ports to speak with 7-segs
void MuxLEDInit (void)
{
    //pins high
    PORTA |=0x03;
    //config direction of ports as outputs
    DDRA |=0x03;
    //pins high
    PORTB=0xff;
    //config direction of ports as outputs
    DDRB=0xff;

    MuxLEDClear();
}

// control segs manually command bit change
void MuxLEDOutCustom (unsigned char Addr, unsigned char Value)
{
     //trim
    Addr &=0x07;
    //no dadta,hex,decode,mornal Op,bank a ,rest adress
    Addr |=0b01110000;    
    //control
    PORTB=Addr;
    MuxLED_MH();
    //latch
    MuxLED_WL();
    MuxLED_WH();
    //data
    PORTB=Value;
    MuxLED_ML();
    //latch
    MuxLED_WL();
    MuxLED_WH();
}

// show HEX decoding (changes all of display to HEX, w/wo dp)
void MuxLEDOutNormal (unsigned char Addr, unsigned char Value, MuxLEDDPOption dp)
{
    //trim
    Addr &=0x07;
    //no dadta,hex,decode,mornal Op,bank a ,rest adress
    Addr |=0b01010000;
    //use dp
    if(dp)
    Value &=(~0x80);
    else
    Value |=0x80;
    //control
    PORTB=Addr;
    MuxLED_MH();
    //latch
    MuxLED_WL();
    MuxLED_WH();
    //data
    PORTB=Value;
    MuxLED_ML();
    //latch
    MuxLED_WL();
    MuxLED_WH();
}

void MuxLEDOut16A (unsigned int Value)
{
    MuxLEDOutNormal(3, (unsigned char)Value&0x0f,MuxLED_DP_OFF);//last number,pos 3
    MuxLEDOutNormal(2, (unsigned char)Value/0x10&0x0f,MuxLED_DP_OFF);
    MuxLEDOutNormal(1, (unsigned char)((Value/0x100)&0x0f),MuxLED_DP_OFF);
    MuxLEDOutNormal(0, (unsigned char)((Value/0x1000)&0x0f),MuxLED_DP_OFF);
}

void MuxLEDOut16B (unsigned int Value)
{
    MuxLEDOutNormal(7, (unsigned char)Value&0x0f,MuxLED_DP_OFF);//last number,pos 3
    MuxLEDOutNormal(6, (unsigned char)Value/0x10&0x0f,MuxLED_DP_OFF);
    MuxLEDOutNormal(5, (unsigned char)((Value/0x100)&0x0f),MuxLED_DP_OFF);
    MuxLEDOutNormal(4, (unsigned char)((Value/0x1000)&0x0f),MuxLED_DP_OFF);
}

// show the 8-bit value starting on the digit as addr (0-6)
void MuxLEDOut8 (unsigned char Addr, unsigned char Value)
{
    MuxLEDOutNormal(Addr,Value&0x0f,MuxLED_DP_OFF);
    MuxLEDOutNormal(Addr+1,(Value/0x10)&0x0f,MuxLED_DP_OFF);
}

void MuxLEDOut16D (unsigned int Value, Line line)
{
    //errors for over decimal val 9999 and over line 0-1
    if(Value>9999)
    {
        //err msge here call custom
        MuxLEDOutCustom(0,0b11001111);//E
        MuxLEDOutCustom(1,0b11001111);//E
        MuxLEDOutCustom(2,0b11001111);//E
    }
    if(line>1)
    {
        //err msge here call custom
        MuxLEDOutCustom(0,0b11111010);//n
        MuxLEDOutCustom(5,0b11111011);//o
    }
    // get on first and second line some with muxNORM
    if(line==0)
    {
    MuxLEDOutNormal(3,Value%10,MuxLED_DP_OFF);
    MuxLEDOutNormal(2,(Value/10)%10,MuxLED_DP_OFF);
    MuxLEDOutNormal(1,(Value/100)%10,MuxLED_DP_OFF);
    MuxLEDOutNormal(0,(Value/1000)%10,MuxLED_DP_OFF);
    }
    else if(line==1)
    {
    MuxLEDOutNormal(7,Value%10,MuxLED_DP_OFF);
    MuxLEDOutNormal(6,(Value/10)%10,MuxLED_DP_OFF);
    MuxLEDOutNormal(5,(Value/100)%10,MuxLED_DP_OFF);
    MuxLEDOutNormal(4,(Value/1000)%10,MuxLED_DP_OFF);
    }    
}
// clear the display
void MuxLEDClear(void)
{
    int i;
    for (i = 0; i < 8; i++)
    {
        MuxLEDOutCustom(i,0x80);//MuxLEDOutCustom(0,0x80);
    }
    
}

// write high
void MuxLED_WH(void)
{
    PORTA |=0x01;
} 
// write low
void MuxLED_WL(void)
{
    PORTA &=(~0x01);
}
// mode high
void MuxLED_MH(void)
{
    PORTA |=0x02;
}
// mode low
void MuxLED_ML(void)
{
    PORTA &=(~0x02);
}
// show a 16-bit value on the upper or lower display