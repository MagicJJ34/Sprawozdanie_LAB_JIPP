// Zadanie 2

printf "Podaj tekst: "
let text = System.Console.ReadLine()

let t = text.Replace(" ", "").ToLower()
let rev = System.String(Array.rev (t.ToCharArray()))

if t = rev then
    printfn "Tekst jest palindromem"
else
    printfn "Tekst nie jest palindromem"
