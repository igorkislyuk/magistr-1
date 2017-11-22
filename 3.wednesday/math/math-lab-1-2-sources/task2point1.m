K = 1023;

k = 0:1:K;

A = 2;

T = 200;

dt = 1;

psi = pi / 4;

X = A * sin(((2*pi*k*dt) / (T)) + psi);

plot(k, X);

xlabel('k');
ylabel('X');