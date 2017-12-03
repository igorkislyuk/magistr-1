clear all 
k=0:1:1000;
E =0;
SIGMA =100;
X1= normcdf(k,E,SIGMA);
SIGMA =200;
X2= normcdf(k,E,SIGMA);
SIGMA =300;
X3= normcdf(k,E,SIGMA);
plot(k,X1, k,X2,'.', k,X3,':')
grid on
