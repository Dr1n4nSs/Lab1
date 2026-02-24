open System
[<EntryPoint>]
printf "Вычисление факториала числа\n"
printf "Введите число - "
let countInput  = Console.ReadLine()

let rec factorial n=
    if n <= 1 then 
        1
    else 
        n * factorial (n - 1)

match Int32.TryParse(countInput) with
| true, n when n >= 0 ->
    let result = factorial n
    printfn "Факториал %d равен %d" n result
| true, _ ->
    printf "Введено отрицательное число, для него не определён факториал"
| _ ->
    printf "Введено некорректное число для вычисления факториала"