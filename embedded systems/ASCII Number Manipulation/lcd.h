////////////////////////////////////////////////////
// 8-Bit interface init on LCD
// LCD is wired to PTH for data, PK0:2 for control :
// 2     1     0     PTK
// A     R/W*  E     LCD
////////////////////////////////////////////////////

// setup ports for LCD (must be called first)
void lcdInit (void);

// send instruction to LCD
void lcdInst (byte val);

// send data to the LCD
void lcdData (byte val);

// set LCD address (manual)
void lcdAddr (byte addr);

// set LCD address (X, Y)
void lcdAddrXY (byte ix, byte iy);

// send string to LCD at current pos
void lcdString (char * straddr);

void lcdStringNewLine (char const * straddr);

// send string to LCD at specific pos
void lcdStringXY (byte ix, byte iy, char * straddr);

// send a character of CG data to the LCD
void lcdCGChar (byte cgAddr, byte const * const cgData);

// clear the display
void lcdClear (void);

// go home
void lcdHome (void);

// shift left
void lcdShiftL (void);

// shift right
void lcdShiftR (void);

// set display options (cursor and blink)
void lcdDispControl (byte curon, byte blinkon);

/*
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
#define lcdRSUp PORTK |= 4;
#define lcdRSDown PORTK &= (~4);
////////////////////////////////////////////////////
*/