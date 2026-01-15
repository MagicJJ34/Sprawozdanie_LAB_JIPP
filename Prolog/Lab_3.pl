%Zadanie1
first([X|_], X).

last([X], X).
last([_|T], X) :-
    last(T, X).

sum_list([], 0).
sum_list([H|T], Sum) :-
    sum_list(T, S),
    Sum is H + S.

%Zadanie2
count_greater([], _, 0).
count_greater([H|T], N, Count) :-
    H > N,
    count_greater(T, N, C),
    Count is C + 1.
count_greater([H|T], N, Count) :-
    H =< N,
    count_greater(T, N, Count).

%Zadanie3
prefix(P, L) :-
    append(P, _, L).

suffix(S, L) :-
    append(_, S, L).

sublist(Sub, L) :-
    suffix(S, L),
    prefix(Sub, S).

%Zadanie4
max_list_acc([H|T], Max) :-
    max_acc(T, H, Max).

max_acc([], Acc, Acc).
max_acc([H|T], Acc, Max) :-
    H > Acc,
    max_acc(T, H, Max).
max_acc([H|T], Acc, Max) :-
    H =< Acc,
    max_acc(T, Acc, Max).

sum_list_acc(L, Sum) :-
    sum_acc(L, 0, Sum).

sum_acc([], Acc, Acc).
sum_acc([H|T], Acc, Sum) :-
    Acc1 is Acc + H,
    sum_acc(T, Acc1, Sum).

product_list_acc(L, Product) :-
    prod_acc(L, 1, Product).

prod_acc([], Acc, Acc).
prod_acc([H|T], Acc, Product) :-
    Acc1 is Acc * H,
    prod_acc(T, Acc1, Product).

%Zadanie5
replace([], _, _, []).
replace([X|T], X, Y, [Y|R]) :-
    replace(T, X, Y, R).
replace([H|T], X, Y, [H|R]) :-
    H \= X,
    replace(T, X, Y, R).

%Zadanie6
all_sublists(L, Sub) :-
    sublist(Sub, L).

%Zadanie7
increasing_sublist(L, R) :-
    findall(Sub,
        ( sublist(Sub, L),
          Sub \= [],
          strictly_increasing(Sub)
        ),
        Subs),
    longest(Subs, R).

strictly_increasing([_]).
strictly_increasing([A,B|T]) :-
    A < B,
    strictly_increasing([B|T]).

longest([H|T], Longest) :-
    longest(T, H, Longest).

longest([], Acc, Acc).
longest([H|T], Acc, Longest) :-
    length(H, L1),
    length(Acc, L2),
    ( L1 > L2 ->
        longest(T, H, Longest)
    ;
        longest(T, Acc, Longest)
    ).

%Zadania_kolejne
%1
remove_last3(L, L1) :-
    append(L1, [_,_,_], L).
%2
remove_first3(L, L1) :-
    append([_,_,_], L1, L).
%3
remove_first_last3(L, L2) :-
    append([_,_,_], Mid, L),
    append(L2, [_,_,_], Mid).
%4
parzysta([]).
parzysta([_,_|T]) :-
    parzysta(T).

nieparzysta([_]).
nieparzysta([_,_|T]) :-
    nieparzysta(T).