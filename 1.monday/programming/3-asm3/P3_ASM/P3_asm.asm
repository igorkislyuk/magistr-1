;Антонов Егор, группа К4120
.device ATmega8535

ldi R16,55
ldi R17,66
k:nop
mov R0,R17
cp R16,R0
brlo stop
brsh k
stop: rjmp stop
