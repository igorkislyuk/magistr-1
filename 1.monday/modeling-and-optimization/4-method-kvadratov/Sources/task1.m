X = [0.05 0.10 0.17 0.25 0.30 0.36];
Y = [0.0500 0.1003 0.1717 0.2553 0.3093 0.3764];
xlabel('X');
ylabel('Y');
hold on
plot(X,Y,'ko')
t = -0.05 : 0.01 : 0.45;
c5 = polyfit(X,Y,5);
y5 = polyval(c5,t);
plot(t, y5, 'k-')
title('Polynom approximation');
legend('Data','Approx.', 'Location', 'west')