a = 2;
b = 5;
N = 25;
x = a + (b-a) * rand(N,1);
hist(x);
F0 = unifcdf(x,a,b);
H = kstest(x, [x,F0])