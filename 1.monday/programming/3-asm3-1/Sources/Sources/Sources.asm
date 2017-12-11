;Kislyuk Igor, K4120, level 11 (11,90,60)
.device ATmega8535

ldi R16, 11 ; A
ldi R17, 90 ; B
ldi R18, 60 ; C

mul R16, R17 ; result to R1:R0

add R16, R17 ; result to R16

sub R16, R18 ; (a + b) - c to R16
