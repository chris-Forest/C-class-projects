;************************************************************************
;* Processor:	MC9S12XDP512											*
;* Xtal Speed:	16 MHz													*
;* Author:	Chris Forest									*
;************************************************************************

;export symbols
		XDEF 		Entry			;export'Entry' symbol
		ABSENTRY 	Entry			;for absolute assembly: app entry point

;include derivative specific macros
		INCLUDE 'derivative.inc'

;********************************************************************
;*		Variables													*
;********************************************************************
		ORG			RAMStart		;Address $2000


;********************************************************************
;*		Code Section												*
;********************************************************************
		ORG			ROM_4000Start	;Address $4000 (FLASH)
Entry:
		LDS			#RAMEnd+1	            	;initialize the stack pointer
		
		CLR     PT1AD1                  ;SET PORT STATES (LED OFF)
		MOVB    #%11100000,DDR1AD1      ;GET LED OUTPUTS, SWITCHES INPUTS
		MOVB    #%00011111,ATD1DIEN1    ;GET SWITCHES DIGITAL INPUTS

MainYellow:
		LDAA    PT1AD1                  ;GET THE STATE OF ENTIRE PORT TO A
		ANDA	#%00000001 		            ;ANDA WITH BIT 00000001 center
		BEQ		YellowLedOff              ;IF RESULT IS ZERO( NO BUTTON PRESSED
		                                ; SKIP YELLOW LED TURNING ON
		                    
		BSET	PT1AD1,#$40               ;YELLOW LED TURNS ON
		BRA		YellowTurnOff             ;SKIP LED TURNING OFF
YellowLedOff:
		BCLR	PT1AD1,#$40               ;TURN OFF YELLOW LED
		
YellowTurnOff:                      ;ALLOW GREEN LED AND BUTTON PRESS
	  
MainGreen:
		LDAA    PT1AD1                  ;GET THE STATE OF ENTIRE PORT TO A
		ANDA	#%0000010			            ;ANDA WITH BIT 00000010 right
		BEQ		GreenLedOff               ;IF RESULT IS ZERO( NO BUTTON PRESSED
		                                ; SKIP GREEN LED TURNING ON
		                    
		BSET	PT1AD1,#$20               ;GREEN LED TURNS ON
		BRA		GreenTurnOff              ;SKIP LED TURNING OFF
GreenLedOff:
		BCLR	PT1AD1,#$20               ;TURN OFF GREEN LED
		
GreenTurnOff:                       ;ALLOW RED LED AND BUTOON PRESS
		
		
MainRed:
		LDAA    PT1AD1                  ;GET THE STATE OF ENTIRE PORT TO A
		ANDA	#%000001000		            ;ANDA WITH BIT 00001000 left
		BEQ		RedLedOff                 ;IF RESULT IS ZERO( NO BUTTON PRESSED
		                                ; SKIP RED LED TURNING ON
		                    
		BSET	PT1AD1,#$80               ;RED LED TURNS ON
		BRA		RedTurnOff                ;SKIP LED TURNING OFF
RedLedOff:
		BCLR	PT1AD1,#$80               ;TURN OFF RED LED
		
RedTurnOff:
	  
	  
MainAll:
    LDAA  PT1AD1                    ;GET THE STATE OF ENTIRE PORT TO A
    ANDA  #%00010000                ;ANDA WITH BIT 00010000 UP  
    BEQ   AllLedOff                 ;IF RESULT IS ZERO( NO BUTTON PRESSED
		                                ; SKIP ALL LEDS TURNING ON
    
    BSET  PT1AD1,#$E0               ;ALL LEDS TURN ON
    BRA   AllTurnOff                ;SKIP ALL LEDS TURING OFF
AllLedOff:
    BCLR  PT1AD1,#$E0               ;TURN OFF ALL LEDS
AllTurnOff:
    BRA   MainYellow                ;DO ANOUTHER PASS

;********************************************************************
;*		Constants													*
;********************************************************************
		ORG			ROM_C000Start	;second block of ROM

;********************************************************************
;*		Absolute Library Includes									*
;********************************************************************

		;INCLUDE "Your_Lib.inc"


;********************************************************************
;*		Interrupt Vectors											*
;********************************************************************

		ORG			$FFFE
		DC.W		Entry			;Reset Vector
