K = 1023;
k = 0:1:K;

r = random('Normal', 0, 1, 1, K + 1);
X = (r) / (k + 1);

plot(k, X);

xlabel('k');
ylabel('X');