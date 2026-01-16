// Zadanie 2

type BankAccount(accountNumber: string, initialBalance: float) =
    let mutable balance = initialBalance
    member _.AccountNumber = accountNumber
    member _.Balance = balance
    member _.Deposit(amount: float) =
        if amount > 0.0 then
            balance <- balance + amount
            printfn "Wpłata: %.2f" amount
    member _.Withdraw(amount: float) =
        if amount > 0.0 && amount <= balance then
            balance <- balance - amount
            printfn "Wypłata: %.2f" amount

type Bank() =
    let mutable accounts : BankAccount list = []
    member _.CreateAccount(acc: BankAccount) =
        accounts <- acc :: accounts
        printfn "Utworzono konto: %s" acc.AccountNumber

    member _.GetAccount(number: string) =
        accounts |> List.tryFind (fun a -> a.AccountNumber = number)

    member this.UpdateAccount(number: string, amount: float) =
        match this.GetAccount(number) with
        | Some acc -> acc.Deposit(amount)
        | None -> printfn "Nie znaleziono konta"

    member _.DeleteAccount(number: string) =
        accounts <- accounts |> List.filter (fun a -> a.AccountNumber <> number)
        printfn "Usunięto konto: %s" number

let bank = Bank()

printf "Podaj numer konta: "
let number = System.Console.ReadLine()

let account = BankAccount(number, 0.0)
bank.CreateAccount(account)

bank.UpdateAccount(number, 500.0)
account.Withdraw(200.0)

printfn "Saldo konta %s: %.2f" account.AccountNumber account.Balance

bank.DeleteAccount(number)

