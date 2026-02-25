open System

let addElement item list = 
    item :: list
    
let connectLists first second = 
    first @ second
    
let searchList value list =
    list |> List.tryFindIndex (fun x -> x = value)

let getElement index list =
    if index < 0 || index >= List.length list then
        None
    else
        Some(List.item index list)

let removeElementByValue value list =
    match searchList value list with
    | Some(idx) -> 
        // Фильтруем список, пропуская первое вхождение индекса
        list 
        |> List.indexed 
        |> List.filter (fun (i, _) -> i <> idx) 
        |> List.map snd
    | None -> 
        list

let readInt prompt =
    printf "%s" prompt
    match Int32.TryParse(Console.ReadLine()) with
    | true, value -> value
    | _ -> 0

let readList prompt =
    printfn "\n%s" prompt
    printf "Введите количество элементов в списке: "
    let count = 
        match Int32.TryParse(Console.ReadLine()) with
        | true, v when v >= 0 -> v
        | _ -> 0

    // Используем генератор списка с yield
    [ 
        for i in 1 .. count do
            printf "Введите элемент #%d: " i
            let element = 
                match Int32.TryParse(Console.ReadLine()) with
                | true, v -> v
                | _ -> 0
            yield element 
    ]

let rec mainLoop list1 list2 =
    printfn "\n--------------------------"
    printfn "Список 1: %A" list1    
    printfn "Список 2: %A" list2
    printfn "1. Добавить элемент в начало первого списка"
    printfn "2. Удалить элемент по значению из первого списка"
    printfn "3. Поиск элемента в первом списке (индекс)"
    printfn "4. Сцепить первый и второй списки"
    printfn "5. Получить элемент по номеру из первого списка"
    printfn "6. Выход"
    printf "Выберите действие: "

    match Console.ReadLine() with
    | "1" ->
        let x = readInt "Введите число для добавления: "
        mainLoop (addElement x list1) list2

    | "2" ->
        let x = readInt "Введите число для удаления: "
        let newList = removeElementByValue x list1
        if newList.Length < list1.Length then 
            printfn "Элемент удален."
        else 
            printfn "Элемент не найден."
        mainLoop newList list2

    | "3" ->
        let x = readInt "Что ищем? "
        match searchList x list1 with
        | Some idx -> printfn "Элемент найден на позиции: %d" idx
        | None -> printfn "Элемент не найден."
        mainLoop list1 list2

    | "4" ->
        printfn "Списки объединены."
        mainLoop (connectLists list1 list2) list2

    | "5" ->
        let idx = readInt "Введите индекс: "
        match getElement idx list1 with
        | Some v -> printfn "Значение на позиции %d: %d" idx v
        | None -> printfn "Индекс вне диапазона!"
        mainLoop list1 list2

    | "6" ->
        printfn "Программа завершена."

    | _ -> 
        printfn "Неверный ввод, попробуйте снова."
        mainLoop list1 list2

[<EntryPoint>]
let main args =
    printfn "Инициализируйте таблицы."
    let initialList1 = readList "Настройка Списка 1"
    let initialList2 = readList "Настройка Списка 2"

    mainLoop initialList1 initialList2
    0