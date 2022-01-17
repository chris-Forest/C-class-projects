
#include "misc.h"
// BCD ops
//unsigned int HexToBCD16 (unsigned int input);
BCDResult NumToBCD16 (unsigned int input, unsigned int * output)
{       //=val
    unsigned int total = 0;
    if(input>=10000)
        return BCD_ERROR;
    total+=((input/1)%10)*1;
    total+=((input/10)%10)*10;
    total+=((input/100)%10)*100;
    total+=((input/1000)%10)*1000;
    *output=total;
    return BCD_OK;
}

//unsigned int BCDToHex16 (unsigned int input);
BCDResult BCDToNum16 (unsigned int input, unsigned int * output)
{
    unsigned int total = 0;
    unsigned int var1=((input/0x01)%0x10);
    unsigned int var2=((input/0x10)%0x10);
    unsigned int var3=((input/0x100)%0x10);
    unsigned int var4=((input/0x1000)%0x10);
    total+=var1*1;
    if(var1>10)
        return BCD_ERROR;
    total+=var2*10;
    if(var2>10)
        return BCD_ERROR;
    total+=var3*100;
    if(var3>10)
        return BCD_ERROR;
    total+=var4*1000;
    if(var4>10)
        return BCD_ERROR;
    *output=total;
    return BCD_OK;
}

void delay(unsigned int count)
{
    int i;
    i/=10;
    for( i=0;i<count;i++)//count # == ms delay in 1 ms ex: count=10-> 10ms delay
    {
        asm LDX #26667;
        asm DBNE X,*;   
    }
}
char lower(char ch)// to lower case
{
    if(ch>='A'&&ch<='Z')
        return ch+0x20;
    else
    {
        return ch;
    }        
}
char upper(char ch)// to uppercase
{
    if(ch>='a'&&ch<='z')
        return ch-0x20;
    else
    {
        return ch;
    }    
}