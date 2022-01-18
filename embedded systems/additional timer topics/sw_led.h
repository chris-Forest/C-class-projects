// Switch and indicator LED library
// Revision History:
// May 9th 2014 - Initial Port to C - Simon Walker
// June 2018 - Minor change to AnyButton, typedef on enum added
// Oct 2018 - Added enum switch function, separated debounce/non-debounce versions
// untouched since gotten by simonon Sept. 15 2020

// types
typedef enum LEDColour // tag values represent actual bit positions
{
  SWL_RED = 0x80,
  SWL_YELLOW = 0x40,
  SWL_GREEN = 0x20
} SWL_LEDColour;

typedef enum SwitchPos // tag values represent actual bit positions
{
  SWL_CTR  = 0b00000001,
  SWL_RIGHT= 0b00000010,
  SWL_DOWN = 0b00000100,
  SWL_LEFT = 0b00001000,
  SWL_UP   = 0b00010000 
} SWL_SwitchPos;

// init - must be called to init port
void SWL_Init (void);
void SWL_PortjInit(void);

// LED functions
void SWL_LED_ON (SWL_LEDColour led);
void SWL_LED_OFF (SWL_LEDColour led);
void SWL_LED_TOG (SWL_LEDColour led);

// by switch name
int SWL_SW_Pushed (SWL_SwitchPos pos);
int SWL_SW_PushedDeb (SWL_SwitchPos pos);
// look for transitions between checks
int SWL_SW_Transition (SWL_SwitchPos pos);

// any switch pushed
int SWL_SW_Any (void);
void DelayTimer1ms(unsigned int limit);