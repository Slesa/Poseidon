% main entry point

:- class('Family').


son(X,Y) :- male(X), father(Y,X).


father(tom,jack).
father(tom,john).


male(jack).
male(john).
