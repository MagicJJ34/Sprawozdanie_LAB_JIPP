// Zadanie 6

printf "Podaj tekst: "
let text = System.Console.ReadLine()

printf "Podaj słowo do wyszukania: "
let oldWord = System.Console.ReadLine()

printf "Podaj słowo na zamianę: "
let newWord = System.Console.ReadLine()

let result = text.Replace(oldWord, newWord)

printfn "Zmodyfikowany tekst:"
printfn "%s" result
