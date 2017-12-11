/*******************************************************
This program was created by the
CodeWizardAVR V2.60 Evaluation
Automatic Program Generator
© Copyright 1998-2012 Pavel Haiduc, HP InfoTech s.r.l.
http://www.hpinfotech.com

Project : 
Version : 
Date    : 11/12/2017
Author  : Kislyuk Igor, K4120
Company : ITMO University
Comments: 


Chip type               : ATmega8
Program type            : Application
AVR Core Clock frequency: 8,000000 MHz
Memory model            : Small
External RAM size       : 0
Data Stack size         : 256
*******************************************************/

#include <mega8.h>

#include <mega8.h>
#define F_CPU 8000000UL // кварц 8 MHz
#include <io.h>
#include <delay.h>

void main(void)
{
  DDRB |= (1 << 2);
  while (1)
  {
    PORTB |= (1 << 2);
    delay_ms(100);
    PORTB &= ~(1 << 2);
    delay_ms(100);
  }

}
