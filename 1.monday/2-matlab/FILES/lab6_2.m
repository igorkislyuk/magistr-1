c1 = -1;
c2 = -1;
a = 7;
b = 7;
R = 18;

d = 0.001;

x1 = 6;
x2 = 7;

k = 1;
kmax = 100;

x1trace = [x1];
x2trace = [x2];

g = @(x1,x2)(R - (x1 - a)^2 - (x2 - b)^2);
dfdx1 = @(x1,x2)(2*c1*x1);
dfdx2 = @(x1,x2)(2*c2*x2);
dgdx1 = @(x1,x2)(-2*x1+2*a);
dgdx2 = @(x1,x2)(-2*x2 +2*b);

gamma = 0.1;
alpha = 1.9;

i=2;
while k<kmax;
    if g(x1,x2)>0;
        step_x1 = dfdx1(x1,x2);
        step_x2 = dfdx2(x1,x2);
    else
        step_x1 = dfdx1(x1,x2) + alpha*dgdx1(x1,x2);
        step_x2 = dfdx2(x1,x2) + alpha*dgdx2(x1,x2);
    end
    new_x1 = max(0, x1+gamma*step_x1);
    new_x2 = max(0, x2+gamma*step_x2);
      
    x1trace(i) = new_x1;
    x2trace(i) = new_x2;
    i = i+1;
    x1 = new_x1;
    x2 = new_x2;
    if (dfdx1(x1,x2)/dgdx1(x1,x2)) - (dfdx2(x1,x2)/dgdx2(x1,x2)) <=d;
        break;
    end;
    k = k+1;
end

x = 0 : 0.1 : 10;
y = 0 : 0.1 : 10;
[X, Y] = meshgrid(x,y);
Zl = (X - a).^2 + (Y - b).^2;
[C, h] = contour(X, Y, Zl, [R R], 'LineWidth',2);
hold on;
Z = c1*X.^2 + c2* Y.^2;
[C, h] = contour(X, Y, Z);
clabel(C, h);
plot(x1trace, x2trace, '-+');

text(x1trace(1) + 0.1, x2trace(1), 'M0');
text(x1 + 0.7, x2, ...
    strvcat(['x1 = ' num2str(x1)],...
            ['x2 = ' num2str(x2)],...
            ['k = ' num2str(k)]));