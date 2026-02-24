open System

let addElement item list = 
    item :: list
    
let connectLists first second = 
    first @ second
    
let searchList value (list: 'T list) =
    let mutable found = None
    let length = list.Length
    
    for i in 0 .. length - 1 do
        if list.[i] = value && found.IsNone then
            found <- Some(i)             
    found

let getElement index (list: 'T list) =
    let length = list.Length
    
    // Проверяем, находится ли номер в диапазоне
    if index < 0 || index >= length then
        printfn "Индекс %d вне диапазона (размер списка: %d)" index length
        None
    else
        let mutable result = list.[0] 
        for i in 0 .. index do
            result <- list.[i]
        
        Some(result)

let removeElementByValue value (list: 'T list) =
    match searchList value list with
    | Some(idx) -> 
        printfn "Элемент %A найден на позиции %d" value idx
        // Создаем новый список, пропуская элемент с индексом idx
        let mutable newList = []
        for i in 0 .. list.Length - 1 do
            if i <> idx then
                newList <- newList @ [list.[i]]
        newList
    | None -> 
        printfn "Элемент %A не найден. Список не изменен." value
        list

//Проверка работы функций 
let mutable myNumbers1 = [10; 25; 30; 45; 50]
let mutable myNumbers2 = [1; 2; 3; 4; 5]
let mutable running = true

while running do
    printfn "--------------------------"
    printfn "Список 1: %A" myNumbers1    
    printfn "Список 2: %A" myNumbers2
    printfn "1. Добавить элемент в начало"
    printfn "2. Удалить элемент по значению"
    printfn "3. Поиск элемента (индекс)"
    printfn "4. Сцепить с другим списком"
    printfn "5. Получить элемент по номеру"
    printfn "6. Выход"
    printf "Выберите действие: "

    let input = Console.ReadLine()
    
    match input with
    | "1" ->
        printf "Введите число для добавления: "
        let x = int(Console.ReadLine())
        myNumbers1 <- addElement x myNumbers1
        printfn "Элемент добавлен."

    | "2" ->
        printf "Введите число для удаления: "
        let x = int(Console.ReadLine())
        let oldLength = myNumbers1.Length
        myNumbers1 <- removeElementByValue x myNumbers1
        if myNumbers1.Length < oldLength then 
            printfn "Успешно удалено."
        else 
            printfn "Элемент не найден."

    | "3" ->
        printf "Что ищем? "
        let x = int(Console.ReadLine())
        match searchList x myNumbers1 with
        | Some idx -> printfn "Элемент найден на позиции: %d" idx
        | None -> printfn "Элемент не найден."

    | "4" ->
        myNumbers1 <- connectLists myNumbers1 myNumbers2
        printfn "Списки объединены."

    | "5" ->
        printf "Введите индекс: "
        let idx = int(Console.ReadLine())
        match getElement idx myNumbers1 with
        | Some v -> printfn "Значение на позиции %d: %d" idx v
        | None -> printfn "Индекс вне диапазона!"

    | "6" ->
        running <- false
        printfn "Программа завершена."

    | _ -> 
        printfn "Неверный ввод, попробуйте снова."