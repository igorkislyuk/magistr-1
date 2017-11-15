clear all
A=2;
T=200;
n1=5;
n2=10;
n3=20;
dt=1;
K=1023;
k=linspace(0,K,1023);
ksi=rand(size(k))*pi/2;
z=(2*pi)*dt/T;
a1=(k+1).^(1/n1);
a2=(k+1).^(1/n2);
a3=(k+1).^(1/n3);
b=(k+1).^(1/2);
X=A./b;
Y1=cos((k.*z.*a1)+ksi);
Y2=cos((k.*z.*a2)+ksi);
Y3=cos((k.*z.*a3)+ksi);
Z1=X.*Y1;
Z2=X.*Y2;
Z3=X.*Y3;
plot(k,Z1,k,Z2,'.',k,Z3,':')
grid on