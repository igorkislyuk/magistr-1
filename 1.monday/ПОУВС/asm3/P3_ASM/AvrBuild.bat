@ECHO OFF
"C:\Program Files (x86)\Atmel\AVR Tools\AvrAssembler2\avrasm2.exe" -S "C:\Users\Admin\Documents\P3_ASM\labels.tmp" -fI -W+ie -o "C:\Users\Admin\Documents\P3_ASM\P3_asm.hex" -d "C:\Users\Admin\Documents\P3_ASM\P3_asm.obj" -e "C:\Users\Admin\Documents\P3_ASM\P3_asm.eep" -m "C:\Users\Admin\Documents\P3_ASM\P3_asm.map" -l "C:\Users\Admin\Documents\P3_ASM\P3_asm.lst" "C:\Users\Admin\Documents\P3_ASM\P3_asm.asm"
