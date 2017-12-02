clear all 
close all
clc 
f = [2 3]; 
A = [1 3; 2 1; 0 1; 3 0];
b = [18 16 5 21] ;
lb = zeros(2,1);
[x,fval] = linprog(-f,A,b,[],[],lb);
x
-fval
