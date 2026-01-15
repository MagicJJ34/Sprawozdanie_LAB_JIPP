//Zadanie 1
open System

let rec fib n = 
    if n <= 1 then n else fib (n - 1) + fib (n - 2)

let fibOptimized n =
    let rec loop n a b =
        if n = 0 then a else loop (n - 1) b (a + b)
    loop n 0 1

printfn "Fib(10): %d" (fibOptimized 10)