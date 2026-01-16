// Zadanie 4

printfn "Podaj dane w formacie: imię; nazwisko; wiek"
printfn "Pusta linia kończy wprowadzanie"

let rec read () =
    let line = System.Console.ReadLine()
    if line = "" then ()
    else
        let p = line.Split(';')
        printfn "%s, %s (%s lat)" (p.[1].Trim()) (p.[0].Trim()) (p.[2].Trim())
        read ()

read ()
