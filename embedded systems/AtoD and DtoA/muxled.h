///////////////////////////////////////////////////////////////////////////////////////////
// MUXLED - Library for manipulating the ICM7218A 7-segment display on the 9S12 board
// 
// Last Modified May 9th 2014 - Port/Fixup to C library
// June 2018 - Cleanup

// device connection
// PA0 - W*
// PA1 - MODE       
// PB0-PB7 - IDO-ID7

// note - decode applies to entire device, not per segment
//  switching decode will flip the whole device contents
// note - even in no decode commands, the device will 
//  briefly change to whatever coding is present in ID6
//  so this bit, while described as 'don't care' should
//  probably be kept high to maintain HEX decoding
//  -- only use code b bit for help/help function

// muxled - for custom decode:
//   40
// 02  20
//   04
// 08  10
//   01   80(off)

// for functions that want to add/kill the decimal point
typedef enum MuxLEDDPOption
{
  MuxLED_DP_OFF, MuxLED_DP_ON
} MuxLEDDPOption;

//for function to go on line one or two
typedef enum Line
{
  one,two
}Line;
// setup ports to speak with 7-segs
void MuxLEDInit (void);

// control segs manually command bit change
void MuxLEDOutCustom (unsigned char Addr, unsigned char Value);

// show HEX decoding (changes all of display to HEX, w/wo dp)
void MuxLEDOutNormal (unsigned char Addr, unsigned char Value, MuxLEDDPOption dp);

// go code B (changes all of display to code b)
void MuxLEDOutCodeB (unsigned char Addr, unsigned char Value);

// show a 16-bit value on the upper or lower display
void MuxLEDOut16A (unsigned int Value);
void MuxLEDOut16B (unsigned int Value);

// show the 8-bit value starting on the digit as addr (0-6)
void MuxLEDOut8 (unsigned char Addr, unsigned char Value);

// clear the display
void MuxLEDClear(void);

// say 'help' as best the 7-segs can show
void MuxLEDSayHelp (void);

// show a decimal value on the first or second line of the 7-segs
void MuxLEDOut16D (unsigned int Value, Line line);

// internal helpers
void MuxLED_WH(void); // write high
void MuxLED_WL(void); // write low
void MuxLED_MH(void); // mode high
void MuxLED_ML(void); // mode low