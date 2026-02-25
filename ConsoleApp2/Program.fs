open System

let rec factorial n=
    if n <= 1 then 
        1
    else 
        n * factorial (n - 1)

[<EntryPoint>]
let main args =
    printf "Вычисление факториала числа\n"
    printf "Введите число - "
    let countInput  = Console.ReadLine()

    match Int32.TryParse(countInput) with
    | true, n when n >= 0 ->
        let result = factorial n
        printfn "Факториал %d равен %d" n result
        0
    | true, _ ->
        printf "Введено отрицательное число, для него не определён факториал"
        0
    | _ ->
        printf "Введено некорректное число для вычисления факториала"
        0