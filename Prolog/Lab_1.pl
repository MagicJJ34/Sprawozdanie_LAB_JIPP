%Zadanie_1
%Fakty
% rodzic(rodzic, dziecko)
rodzic(zofia, marcin).
rodzic(andrzej, marcin).
rodzic(andrzej, kasia).
rodzic(marcin, ania).
rodzic(marcin, krzys).
rodzic(krzys, mikolaj).

kobieta(zofia).
kobieta(kasia).
kobieta(ania).

mezczyzna(andrzej).
mezczyzna(marcin).
mezczyzna(krzys).
mezczyzna(mikolaj).

%Reguły
potomek(Y, X) :- rodzic(X, Y).

matka(X, Y) :-
    kobieta(X),
    rodzic(X, Y).

dziadkowie(X, Z) :-
    rodzic(X, Y),
    rodzic(Y, Z).

siostra(X, Y) :-
    kobieta(X),
    rodzic(Z, X),
    rodzic(Z, Y),
    X \= Y.

brat(X, Y) :-
    X \= Y,
    mezczyzna(X),
    rodzic(Z, X),
    rodzic(Z, Y).

%Zadanie_2
%Fakty
lubi(jan, siatkowka).
lubi(janusz, 'pilka nozna').
lubi(rafal, wyscigi).
intensywnosc(wyscigi, wysoka).
intensywnosc('pilka nozna', mala).
intensywnosc(siatkowka, sredni).
miejsce(siatkowka, indoor).
miejsce(wyscigi, natura).
miejsce('pilka nozna', natura).
wiek(jan, 40).
wiek(rafal, 24).
wiek(janusz, 32).
koszt(wyscigi, 20).
koszt('pilka nozna', 5).
koszt(siatkowka, 10).

%Reguły
zainteresowania(X, Y) :- lubi(X, Y).
wspolne_zainteresowania(X, Y, Z) :-
    lubi(X, Z),
    lubi(Y, Z),
    X \= Y.
aktywnosc(X, Y) :- intensywnosc(X, Y).
aktywnosc_na_zewnatrz(X) :-  miejsce(X, natura).
lubi_nature(X) :-
    lubi(X, A),
    miejsce(A, natura).
tania_aktywnosc(X) :-
    koszt(X , Y),
    Y =< 10.
