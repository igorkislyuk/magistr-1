
#include <tiny10.h>
#define F_CPU 8000000UL // кварц 8 MHz
#include <io.h>
#include <delay.h>

// Declare your global variables here

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
