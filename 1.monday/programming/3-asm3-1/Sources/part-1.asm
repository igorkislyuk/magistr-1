;Kislyuk Igor, K4120
.device ATmega8535

ldi R16, 55
ldi R17, 66
k:nop ; no operation
mov R0, R17 ; to R0
cp R16, R0 ; compare!
brlo stop ; to `stop` if lower
brsh k ; to `k` if greater or equal
stop: rjmp stop ; transition to `k` label ?
