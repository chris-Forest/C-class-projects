#include <hidef.h>
#include "derivative.h"
#include "lcd.h"
////////////////////////////////////////////////////
// private helpers in implementation file //////////
////////////////////////////////////////////////////
// set the R/W* line high (reading)
// manipulate direction of data port here (for all)
void lcdRWUp (void)
{
  DDRH = 0;         // gotta be inputs
  PORTK |= 2;       // set R/W* high
}

// set the R/W* line low (writing)
// manipulate direction of data port here (for all)
void lcdRWDown (void)
{   
  PORTK &= (~2);    // set R/W* low
  DDRH = 0xff;      // gotta be outputs
}                                  

// add delay when up... otherwise too fast?
#define lcdEUp PORTK |= 1; asm nop;
#define lcdEDown PORTK &= (~1);
#define lcdRSUp PORTK |= 4; //adress
#define lcdRSDown PORTK &= (~4); //adress
////////////////////////////////////////////////////
void lcdBusy(void)
{
    byte inVal=0;
    lcdRSDown;
    lcdRWUp();

    do
    {
        lcdEUp;
        inVal=PTH;
        lcdEDown;

    }while (inVal&0x80);
    
}
// setup ports for LCD (must be called first)
void lcdInit (void)
{
    PTH=0x38;

    lcdEDown;
    lcdRWDown();
    lcdRSDown;

    DDRK |=(0x07);

    //delay 50ms
    asm LDX #0;
    asm DBNE x,*;
    asm DBNE x,*;

    //first call
    lcdEUp;
    lcdEDown;
    asm LDX #11000;
    asm DBNE x,*;
    
    //second call
    lcdEUp;
    lcdEDown;
    asm LDX #267;
    asm DBNE x,*;

    //last call
    lcdEUp;
    lcdEDown;

    lcdInst(0x38);
    lcdInst(0x0c);
    lcdInst(0x01);
    lcdInst(0x06);
}

// send instruction to LCD
void lcdInst (byte val)
{
    lcdBusy();

    lcdEDown;
    lcdRWDown();
    lcdRSDown;

    PTH=val;
    lcdEUp;
    lcdEDown;
}

// send data to the LCD
void lcdData (byte val)
{
    lcdBusy();

    lcdEDown;
    lcdRWDown();
    lcdRSUp;

    PTH=val;
    lcdEUp;
    lcdEDown;
}
// set LCD address (manual)
void lcdAddr (byte addr)
{
    addr |=0b10000000;
    lcdInst(addr);
}

// set LCD address (X, Y)
void lcdAddrXY (byte ix, byte iy)
{
    if(iy==0)
        iy=0;
    else if(iy==1)
        iy=0x40;
    else if(iy==2)
        iy=0x14;
    else if(iy==3)
        iy=0x54;
    lcdAddr(iy+=ix);
}

// send string to LCD at current pos
void lcdString (char * straddr)
{
    //call data
    while (*straddr!=0)
    {
        lcdData(*straddr);
        straddr++;
    }    
}

void lcdStringNewLine (char const * straddr)
{
    int x=0; int y=0;

    lcdAddrXY(x,y);
    for(straddr;*straddr!='\0';++straddr)
    {
        if(*straddr!='\n')
            lcdData(*straddr);
        x+=*straddr!='\n'?1:0;
        if(*straddr=='\n')
        {
            y++;
            x=0;
        }
        lcdAddrXY(x,y);
    }
}


// send string to LCD at specific pos
void lcdStringXY (byte ix, byte iy, char * straddr)
{
    lcdAddrXY(ix,iy);
    lcdString(straddr);
}

void lcdClear (void)
{
    lcdInst(0b00000001);
}

// go home
void lcdHome (void)
{
    lcdInst(0b00000010);
}
// set display options (cursor and blink)
void lcdDispControl (byte curon, byte blinkon)
{
    byte command= 0b00001100;//or byte
    //IF ELSE call lcdinst
    if(curon)
    {
        command |= 0b00000010;
        //lcdInst(command);
    }
    if(blinkon)
    {
        command |=0b00000001;        
        //lcdInst(command);
    }
    lcdInst(command);
}