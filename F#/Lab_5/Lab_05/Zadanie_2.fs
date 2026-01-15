// Zadanie 2
open System

type Tree = L | N of int * Tree * Tree

let rec searchRec v t =
    match t with
    | L -> false
    | N(x, l, r) -> if x = v then true else searchRec v l || searchRec v r

let searchIter v t =
    let mutable s = [t]
    let mutable res = false
    while not s.IsEmpty && not res do
        let cur = s.Head
        s <- s.Tail
        match cur with
        | N(x, l, r) -> if x = v then res <- true else s <- l :: r :: s
        | L -> ()
    res

let tree = N(1, N(2, L, L), N(3, L, L))
printfn "%b" (searchRec 2 tree)
printfn "%b" (searchIter 4 tree)zewo)
