// misc library
// Last Modified : Nov 21 2014
// Revision History:
// Mods to C - Simon Walker

typedef enum BCDResult
{
    BCD_OK,     // bcd conversion was OK
    BCD_ERROR   // bcd conversion had error (can add more error codes if you want to be specific)
} BCDResult;

// functions for ICA #06 1201
/////////////////////////////

// BCD ops
//unsigned int HexToBCD16 (unsigned int input);
BCDResult NumToBCD16 (unsigned int input, unsigned int * output);

//unsigned int BCDToHex16 (unsigned int input);
BCDResult BCDToNum16 (unsigned int input, unsigned int * output);

// optional
//unsigned long HexToBCD32 (unsigned long input);
BCDResult HexToBCD32 (unsigned long input, unsigned long * output);

//unsigned long BCDToHex32 (unsigned long input);
BCDResult BCDToHex32 (unsigned long input, unsigned long * output);
void delay(unsigned int count);
char lower(char ch);
char upper(char ch);


// other functions, may or may not get to them
//////////////////////////////////////////////

/*
// return the string representation of the byte in binary + null
void To8BitString (byte val, char * target);

// return ASCII codes for val in HL of return
unsigned int HexToASCII (byte val);

// return ASCII code for L4bits in val
char HexToASCII4 (byte val);

// assume buffer holds SXXXXX.XXN, leading zero == space
void GetFloatString16 (char * buff, double val);

// convert a 4 digit BCD value to a buffer XXXX (no null inserted!)
void BCDTo4DigHex (char * target, unsigned int bcd);

// assume buffer avail DDN (pop buff as 2 digit dec ASCII)
void Dec02ToASCII (char * buff, unsigned int val);

// assume buffer avail DDDN (pop buff as 3 digit dec ASCII)
void Dec03ToASCII (char * buff, unsigned int val);

// assume buffer avail DDDDN (pop buff as 4 digit dec ASCII)
void Dec04ToASCII (char * buff, unsigned int val);
*/


