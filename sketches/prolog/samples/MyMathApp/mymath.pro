% some math predicates

:- class('MyMath').


factorial(0,1).
factorial(N,F) :- N > 0, M is N - 1, factorial(M,Fm), F is N * Fm.

fib(0,1).
fib(1,1).
fib(N,F) :- N > 1, N1 is N - 1, N2 is N - 2, fib(N1,F1), fib(N2,F2), F is F1 + F2.

min(M,N,M) :- M < N.
min(M,N,N) :- N < M.

