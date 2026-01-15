// Zadanie 5
open System

let rec quicksort list =
    match list with
    | [] -> []
    | pivot :: tail ->
        let smaller = tail |> List.filter (fun x -> x <= pivot)
        let larger = tail |> List.filter (fun x -> x > pivot)
        quicksort smaller @ [pivot] @ quicksort larger

printfn "Posortowane: %A" (quicksort [5; 2; 8; 1; 9])
