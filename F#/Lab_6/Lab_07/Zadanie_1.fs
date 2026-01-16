// Zadanie 1

type Book(title: string, author: string, pages: int) =
    member _.Title = title
    member _.Author = author
    member _.Pages = pages
    member _.GetInfo() =
        sprintf "%s - %s (%d stron)" title author pages

type User(name: string) =
    let mutable borrowed : Book list = []
    member _.Name = name
    member _.BorrowBook(book: Book) =
        borrowed <- book :: borrowed
        printfn "Wypożyczono: %s" (book.GetInfo())
    member _.ReturnBook(book: Book) =
        borrowed <- borrowed |> List.filter (fun b -> b <> book)
        printfn "Zwrócono: %s" (book.GetInfo())

type Library() =
    let mutable books : Book list = []
    member _.AddBook(book: Book) =
        books <- book :: books
        printfn "Dodano książkę: %s" (book.GetInfo())
    member _.RemoveBook(book: Book) =
        books <- books |> List.filter (fun b -> b <> book)
        printfn "Usunięto książkę: %s" (book.GetInfo())
    member _.ListBooks() =
        printfn "Aktualne książki w bibliotece:"
        books |> List.iter (fun b -> printfn "%s" (b.GetInfo()))

printf "Podaj imię użytkownika: "
let userName = System.Console.ReadLine()
let user = User(userName)

let library = Library()

let book1 = Book("Hobbit", "Tolkien", 310)
let book2 = Book("1984", "Orwell", 328)

library.AddBook(book1)
library.AddBook(book2)

library.ListBooks()

user.BorrowBook(book1)
library.RemoveBook(book1)

library.ListBooks()

user.ReturnBook(book1)
library.AddBook(book1)

library.ListBooks()
