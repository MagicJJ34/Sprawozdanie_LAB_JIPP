// Zadanie 4
open System

let rec hanoi n source target auxiliary =
    if n > 0 then
        hanoi (n - 1) source auxiliary target
        printfn "Przenies krazek %d z %s do %s" n source target
        hanoi (n - 1) auxiliary target source

hanoi 3 "A" "C" "B"