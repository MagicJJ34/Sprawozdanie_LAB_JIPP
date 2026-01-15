//Zadanie 1
open System

let readInt () =
    let mutable ok = false
    let mutable v = 0
    while not ok do
        match Int32.TryParse(Console.ReadLine()) with
        | true, x -> v <- x; ok <- true
        | _ -> printfn "Błąd, podaj liczbę:"
    v

printf "Ile liczb? "
let n = readInt ()

if n <= 0 then
    printfn "Błąd"
else
    let nums = [ for _ in 1..n -> readInt () ]
    printfn $"Suma: {List.sum nums}"
    printfn $"Średnia: {float (List.sum nums) / float n}"
    printfn $"Min: {List.min nums}"
    printfn $"Max: {List.max nums}"