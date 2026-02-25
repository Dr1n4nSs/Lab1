open System
[<EntryPoint>]
let main list = 
    printf "Создание списка модулей введённых элементов\n"
    printf "Введите количество чисел - "
    let countInput  = Console.ReadLine()
    
    match Int32.TryParse(countInput) with
    | true, n when n > 0 ->
        let make_spisok = [
            for i in 1..n do
                printf"\nВведите элемент %d - " i
                let number = Console.ReadLine()        
                match Double.TryParse(number) with
                | true, value ->
                    let modul = abs(value)
                    yield modul
        ]
        printf"\nРезультат - %A" make_spisok
        0
    | true, 0 ->
        printf "Колличество элементов равно 0, список будет пустым"
        0
    | _ ->
        printf "Введено некорректное число элементов"
        0