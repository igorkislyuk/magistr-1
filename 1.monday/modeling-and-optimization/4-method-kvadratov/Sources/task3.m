X = [-3 -1 0 1 3];
Y = [-4 -0.8 1.6 2.3 1.5];
xlabel('X');
ylabel('Y');
hold on
plot(X,Y,'ko')
t = -5 : 0.01 : 5;
c2 = polyfit(X,Y,3);
y2 = polyval(c2,t);
plot(t, y2, 'k-')
title('Polynom approximation');
legend('Data','linear approx','location','northwest')