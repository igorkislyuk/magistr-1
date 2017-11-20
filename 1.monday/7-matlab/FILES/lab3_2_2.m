L = 0.2;
N = 25;
x = -1/L * log(rand(N,1));
hist(x,10);
fig2 = figure(2);
x2 = 0:1:max(x);
xt = exppdf(x2,1/L);
plot(x2,xt);

F0 = expcdf(x,1/L);
H = kstest(x,[x,F0])