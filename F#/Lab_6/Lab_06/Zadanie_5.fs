// Zadanie 5

printf "Podaj tekst: "
let text = System.Console.ReadLine()

let longest =
    text.Split(' ')
    |> Array.maxBy String.length

printfn "Najdłuższe słowo: %s" longest
printfn "Długość słowa: %d" longest.Length
