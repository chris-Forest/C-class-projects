// timer header

typedef enum TimerPinAction
{
  Timer_Pin_Disco = 0,
  Timer_Pin_Toggle = 1,
  Timer_Pin_Clear = 2,
  Timer_Pin_Set = 3
} TimerPinAction;

// timer general (uses OC0 - toggle pin)
// prescale value as 2^N (0 - 7 as argument = bus / (1 to 128)) in general, 7 would be used (div by 128)
// uiOffset is initial offset from TCNT
// enableInt is flag for enabling interrupts on OC0
//void TimerInit (unsigned long ulBusClock, unsigned char prescale, unsigned int uiOffset, int enableInt, TimerPinAction pinAction);
void timerinit(unsigned char prescale, unsigned int uiOffset, int enableInt, TimerPinAction pinAction);

// blocking delay for x ms - requires previous InitTimer call
// requires bus/128 in InitTimer call
// range is 1 to 1048ms, uses OC6 (no pin action)
void sleep (float ms);
