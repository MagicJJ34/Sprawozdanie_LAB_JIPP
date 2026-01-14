%Zadanie2
wieksza(X, Y) :-
    X > Y, !,
    write(X), write(' > '), write(Y).
wieksza(X, Y) :-
    X < Y, !,
    write(Y), write(' > '), write(X).
wieksza(_, _) :- 
    write('Liczby sa rowne').

max(X, Y, X) :- X >= Y, !.
max(_, Y, Y).

czy_parzysta(X) :-
    integer(X),
    0 is X mod 2.

%Zadanie3
silnia(0, 1).
silnia(N, W) :-
    N > 0,
    N1 is N - 1,
    silnia(N1, W1),
    W is N * W1.

suma(1, 1).
suma(X, Y) :-
    X > 1,
    X1 is X - 1,
    suma(X1, Y1),
    Y is Y1 + X.

fib(0, 0).
fib(1, 1).
fib(X, Y) :-
    X > 1,
    X1 is X - 1,
    X2 is X - 2,
    fib(X1, Y1),
    fib(X2, Y2),
    Y is Y1 + Y2.

nwd(X, 0, X).
nwd(X, Y, D) :-
    Y > 0,
    M is X mod Y,
    nwd(Y, M, D).

%Zadanie4
%produkt(Nazwa, Cenazasztuke, iloscnastanie).
produkt(jablko, 2.50, 10).
produkt(gruszka, 3.20, 6).
produkt(banan, 4.50, 12).
produkt(ananas, 7.00, 4).

wartosc_produktu(Nazwa, W) :-
    produkt(Nazwa, Cena, Ilosc),
    W is Cena * Ilosc.

wartosc_magazynu(W) :-
    findall(Wart, (produkt(_, C, I), Wart is C * I), Lista),
    sum_list(Lista, W).

drogi_produkt(Nazwa) :-
    produkt(Nazwa, Cena, _),
    Cena > 4.
%Zadanie5
%rachunek(Miesiac, rodzaj, cena).
rachunek(styczen, prad, 120).
rachunek(styczen, gaz, 240).
rachunek(styczen, internet, 70).
rachunek(luty, prad, 130).
rachunek(luty, gaz, 210).
rachunek(luty, internet, 70).
rachunek(luty, woda, 65).

suma_miesiac(Miesiac, S) :-
    findall(Cena, rachunek(Miesiac, _, Cena), Lista),
    sum_list(Lista, S).

srednia_miesiac(Miesiac, Sr) :-
    findall(Cena, rachunek(Miesiac, _, Cena), Lista),
    sum_list(Lista, Suma),
    length(Lista, Ilosc),
    Ilosc > 0,
    Sr is Suma / Ilosc.

porownaj_miesiace(M1, M2, Wynik) :-
    suma_miesiac(M1, S1),
    suma_miesiac(M2, S2),
    ( S1 > S2 -> Wynik = M1
    ; S2 > S1 -> Wynik = M2
    ; Wynik = remis ).

%Zadanie6
% pracownik(Imie, Podstawa, Premia).
pracownik(jan,   4800, 500).
pracownik(anna,  5200, 800).
pracownik(piotr, 4500, 300).
pracownik(kasia, 6000, 1000).

brutto(X, B) :-
    pracownik(X, P, Prem),
    B is P + Prem.

podatek17(X, T) :-
    brutto(X, B),
    T is B * 0.17.

netto(X, N) :-
    brutto(X, B),
    podatek17(X, T),
    N is B - T.

czy_zarabia_wiecej(X, Y, Kto) :-
    netto(X, NX),
    netto(Y, NY),
    ( NX > NY -> Kto = X
    ; NY > NX -> Kto = Y
    ; Kto = remis ).
