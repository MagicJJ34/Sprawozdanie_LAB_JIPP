open System

// Struktura listy łączonej
type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

// Typ dla indeksu
type IndexResult =
    | Found of int
    | NotFound

module LinkedList =
    // 1. Tworzenie listy
    let rec fromList list =
        match list with
        | [] -> Empty
        | head :: tail -> Node(head, fromList tail)

    // Wyświetlanie
    let rec printList list =
        match list with
        | Empty -> printf "[]"
        | Node(value, Empty) -> printf "%A" value
        | Node(value, next) ->
            printf "%A -> " value
            printList next
        printfn ""

    // 2. Sumowanie
    let rec sumList list =
        match list with
        | Empty -> 0
        | Node(value, next) -> value + sumList next

    // 3. Max i Min
    let findMinMax list =
        let rec aux lst minVal maxVal =
            match lst with
            | Empty -> (minVal, maxVal)
            | Node(v, next) -> aux next (min v minVal) (max v maxVal)
        match list with
        | Empty -> failwith "Lista jest pusta"
        | Node(v, next) -> aux next v v

    // 4. Odwracanie
    let reverse list =
        let rec aux acc lst =
            match lst with
            | Empty -> acc
            | Node(v, next) -> aux (Node(v, acc)) next
        aux Empty list

    // 5. Sprawdzanie obecności
    let rec contains element list =
        match list with
        | Empty -> false
        | Node(v, next) -> if v = element then true else contains element next

    // 6. Indeks elementu
    let indexOf element list =
        let rec aux lst idx =
            match lst with
            | Empty -> NotFound
            | Node(v, next) -> if v = element then Found idx else aux next (idx + 1)
        aux list 0

    // 7. Liczenie wystąpień
    let rec countOccurrences element list =
        match list with
        | Empty -> 0
        | Node(v, next) -> (if v = element then 1 else 0) + countOccurrences element next

    // 8. Łączenie list
    let rec append list1 list2 =
        match list1 with
        | Empty -> list2
        | Node(v, next) -> Node(v, append next list2)

    // 9. Porównywanie list (zwraca listę bool)
    let rec compareLists list1 list2 =
        match list1, list2 with
        | Empty, Empty -> []
        | Node(v1, next1), Node(v2, next2) -> (v1 > v2) :: compareLists next1 next2
        | _ -> failwith "Listy mają różną długość!"

    // 10. Filtrowanie
    let rec filter predicate list =
        match list with
        | Empty -> Empty
        | Node(v, next) -> 
            if predicate v then Node(v, filter predicate next)
            else filter predicate next

    // 11. Usuwanie duplikatów
    let removeDuplicates list =
        let rec aux seen lst =
            match lst with
            | Empty -> Empty
            | Node(v, next) ->
                if List.contains v seen then aux seen next
                else Node(v, aux (v :: seen) next)
        aux [] list

    // 12. Podział
    let partition predicate list =
        let list1 = filter predicate list
        let list2 = filter (predicate >> not) list
        (list1, list2)

// Funkcja do bezpiecznego wczytywania liczb z konsoli
let readIntList () =
    Console.ReadLine().Split([|' '; '\t'; '\r'; '\n'|], StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList
    |> List.choose (fun s -> 
        match Int32.TryParse(s) with
        | (true, v) -> Some v
        | _ -> None)

let rec menu (currentList: LinkedList<int>) =
    printfn "\n----------------------------"
    printf "Aktualna lista: "; LinkedList.printList currentList
    printfn "1. Wprowadź listę | 2. Suma | 3. Max/Min | 4. Odwróć"
    printfn "5. Czy istnieje?  | 6. Indeks | 7. Policz | 8. Połącz"
    printfn "9. Porównaj listy | 10. Filtruj (>10) | 11. Usuń duplikaty"
    printfn "12. Podziel (parzyste/nieparzyste) | 0. Wyjście"
    printf "Wybór: "
    
    match Console.ReadLine() with
    | "1" ->
        printf "Podaj liczby po spacji: "
        menu (LinkedList.fromList (readIntList()))
    | "2" ->
        if currentList = Empty then printfn "Lista jest pusta."
        else printfn "Suma: %d" (LinkedList.sumList currentList)
        menu currentList
    | "3" ->
        try
            let minV, maxV = LinkedList.findMinMax currentList
            printfn "Min: %d, Max: %d" minV maxV
        with e -> printfn "Błąd: %s" e.Message
        menu currentList
    | "4" -> menu (LinkedList.reverse currentList)
    | "5" ->
        printf "Szukany element: "
        let x = readIntList() |> List.tryHead
        match x with
        | Some v -> printfn "Czy jest: %b" (LinkedList.contains v currentList)
        | None -> printfn "Nie podano liczby."
        menu currentList
    | "6" ->
        printf "Szukany element: "
        let x = readIntList() |> List.tryHead
        match x with
        | Some v ->
            match LinkedList.indexOf v currentList with
            | Found i -> printfn "Indeks: %d" i
            | NotFound -> printfn "Nie znaleziono (NotFound)"
        | None -> printfn "Nie podano liczby."
        menu currentList
    | "7" ->
        printf "Element: "
        let x = readIntList() |> List.tryHead
        match x with
        | Some v -> printfn "Wystąpienia: %d" (LinkedList.countOccurrences v currentList)
        | None -> printfn "Nie podano liczby."
        menu currentList
    | "8" ->
        printf "Podaj drugą listę: "
        let secondList = LinkedList.fromList (readIntList())
        menu (LinkedList.append currentList secondList)
    | "9" ->
        try
            printf "Podaj drugą listę o tej samej długości: "
            let secondList = LinkedList.fromList (readIntList())
            let results = LinkedList.compareLists currentList secondList
            printfn "Wyniki (L1 > L2): %A" results
        with e -> printfn "Błąd: %s" e.Message
        menu currentList
    | "10" -> menu (LinkedList.filter (fun x -> x > 10) currentList)
    | "11" -> menu (LinkedList.removeDuplicates currentList)
    | "12" ->
        let p1, p2 = LinkedList.partition (fun x -> x % 2 = 0) currentList
        printf "Spełniają (parzyste): "; LinkedList.printList p1
        printf "Pozostałe (nieparzyste): "; LinkedList.printList p2
        menu currentList
    | "0" -> printfn "Koniec programu."
    | _ -> 
        printfn "Niepoprawny wybór."
        menu currentList

// Start programu
menu Empty