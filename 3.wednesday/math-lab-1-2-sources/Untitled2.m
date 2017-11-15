clear all 
k=0:1:1000;
E=1.5;
SIGMA=1;
X=normcdf(k,E,SIGMA);
figure(1)
plot(k,X)
xlabel('k')
ylabel('X')