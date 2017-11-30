clc;
N = 500;
x=0;
for J = 1 : N
    x(J) = sum(rand(12,1))-6;
end
hist(x,25)
m = mean(x);
s = std(x);
fprintf('\n\t m = %g\n', m)
fprintf('\n\t s = %g\n', s)