// MPL3115 Library (simple operations)

// command representation of device address (0x60 as 7-bit address)
#define MPL3115_ADDR 0xC0

// this device can run at 400KHz (tested)
// MPL3115 Functions (requires I2C bus to already be initialized)
void MPL3115_Init (void); 

// check temp ready flag
int MPL3115_TRdy (void);

// check pressure reay flag
int MPL3115_PRdy (void);

// get a temperature reading in C, as float
float MPL3115_GetT (void);

// get a pressure reading in kPa, as float
float MPL3115_GetP (void);


// support functions (used internally)
// front-end for device read (1 byte)
//unsigned char MPL3115_Read (unsigned char addr);
// front-end for device write (1 byte)
//void MPL3115_Write (unsigned char reg, unsigned char data);


