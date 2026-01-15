//Zadanie 4
open System

type Student = { Name:string; Age:int; Grade:float }

let students = [
    {Name="Jan"; Age=20; Grade=4.5}
    {Name="Robert"; Age=21; Grade=3.5}
    {Name="Łukasz"; Age=22; Grade=4.0}
    {Name="Hubert"; Age=23; Grade=5.0}
]

students
|> List.filter (fun s -> s.Grade >= 4.0)
|> List.iter (printfn "%A")

students
|> List.map (fun s -> { s with Age = s.Age + 1 })
|> List.iter (printfn "%A")