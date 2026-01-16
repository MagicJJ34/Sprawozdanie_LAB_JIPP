// Zadanie 3

printf "Podaj słowa oddzielone spacjami: "
let input = System.Console.ReadLine()

let result =
    input.Split(' ')
    |> Array.distinct

printfn "Unikalne słowa:"
result |> Array.iter (printfn "%s")
