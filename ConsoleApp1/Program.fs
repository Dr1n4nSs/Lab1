open System
[<EntryPoint>]
printf "Создание списка модулей введённых элементов\n"
printf "Введите количество чисел - "
let countInput  = Console.ReadLine()

match Int32.TryParse(countInput) with
| true, n when n > 0 ->
    let mutable spisok = []
    for i in 1..n do
        printf"\nВведите элемент %d - " i
        let mutable number = Console.ReadLine()        
        match Double.TryParse(number) with
        | true, value ->
            spisok <- abs(value) :: spisok 
        | _ ->
            printf "\nВведено некорректное значение элемента"
    let spisok = List.rev spisok
    printf"\nРезультат - %A" spisok
| true, 0 ->
    printf "Колличество элементов равно 0, список будет пустым"
| _ ->
    printf "Введено некорректное число элементов"