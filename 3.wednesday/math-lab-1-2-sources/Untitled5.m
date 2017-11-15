clear all 
k=0:1:1000;
SIGMA=20;
E =0;
X1= normcdf(k,E,SIGMA);
E =2;
X2= normcdf(k,E,SIGMA);
E =4;
X3= normcdf(k,E,SIGMA);
plot (k,X1,k,X2,'.',k,X3,':')
grid on