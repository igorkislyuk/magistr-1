clear all 
close all
clc 
f = [18 16 5 21]; 
A = [1 2 0 3; 3 1 1 0];
b = [2 3] ;
lb = zeros(4,1);
ub = [18 16 5 21];
[x,fval] = linprog(f,-A,-b,[],[],lb, ub);
x
fval
