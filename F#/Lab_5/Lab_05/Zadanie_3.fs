//Zadanie 3

open System

let rec permutations list =
    match list with
    | [] -> [[]]
    | x :: xs ->
        permutations xs |> List.collect (fun p ->
            [for i in 0..p.Length -> (List.take i p) @ [x] @ (List.skip i p)])

printfn "Permutacje: %A" (permutations [1; 2; 3])