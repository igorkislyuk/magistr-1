c1 = -2;
c2 = -1;
c12 = 1;
g = 0.5;
d = 0.01;
l = 0.5;

x1 = 16;
x2 = 18;

k = 1;
kmax = 100;

x1trace = [x1];
x2trace = [x2];

gr1 = 2*c1*x1 + c12*x2;
gr2 = 2*c2*x2 +c12*x1;

i=2;
while k<kmax;
    grS = sqrt(gr1^2 + gr2^2);
    x1 = x1+g*gr1;
    x2 = x2+g*gr2; 
    
    new_gr1 = 2*c1*x1 + c12*x2;
    new_gr2 = 2*c2*x2 +c12*x1;
    
    gr = sqrt(new_gr1^2 + new_gr2^2);
    if gr < grS;
       gr1 = new_gr1;
       gr2 = new_gr2;
       x1trace(i) = x1;
       x2trace(i) = x2;
       i = i+1;
       if sqrt(gr1^2 + gr2^2) <= d;
           break;
       end
    k = k+1;
    else
        x1 = x1 - g*gr1;
        x2 = x2 - g*gr2;
        g = l*g;
    end
end

x = -20 : 0.1 : 20;
y = -20 : 0.1 : 20;
[X, Y] = meshgrid(x,y);
Z = c1*X.^2 + c2*Y.^2 + c12*X.*Y;
[C, h] = contour(X, Y, Z);
clabel(C, h);
hold on;

plot(x1trace, x2trace, '-');
text(x1trace(1) + 0.2, x2trace(1) + 0.5, 'M0');
text(x1 + 2.5, x2, ...
    strvcat(['x1 = ' num2str(x1)],...
            ['x2 = ' num2str(x2)],...
            ['k = ' num2str(k)]));