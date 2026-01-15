//Zadanie 3
open System

printfn "Podaj liczbe elementow (n):"
let n = int (Console.ReadLine())

printfn "Podaj %d liczb (kazda w nowej linii):" n
let nums = [ for _ in 1..n -> int (Console.ReadLine()) ]

printfn "Liczba dodatnich: %d" (nums |> List.filter (fun x -> x > 0) |> List.length)
printfn "Kwadraty liczb: %A" (nums |> List.map (fun x -> x * x))
printfn "Suma: %d" (nums |> List.fold (+) 0)