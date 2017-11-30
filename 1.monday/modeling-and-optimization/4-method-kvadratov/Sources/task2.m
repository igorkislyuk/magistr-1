X = [-2 -1 0 1 2];
Y = [0 0 1 0 0];
xlabel('X');
ylabel('Y');
hold on
plot(X,Y,'ko')
t = -3 : 0.1 : 3;
c2 = polyfit(X,Y,1);
y2 = polyval(c2,t);
plot(t, y2, 'k:')
c4 = polyfit(X,Y,4);
y4 = polyval(c4,t);
plot(t, y4, 'k-')
title('Polynom approximation');
legend('Data','poly 2 degree','poly 4 degree', 'location', 'west')