// Zadanie 1

printf "Podaj tekst: "
let text = System.Console.ReadLine()

let words =
    text.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.length

let chars = text.Replace(" ", "").Length

printfn "Liczba słów: %d" words
printfn "Liczba znaków (bez spacji): %d" chars
