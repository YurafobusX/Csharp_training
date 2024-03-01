using Algrorithm;


// первая задача
try {
    var input = Console.ReadLine();
    if (input == null || input.Length == 0) return;
    Algrorithm.Algrorithm.check(input);

    var processed = Algrorithm.Algrorithm.process(input);
    var count = Algrorithm.Algrorithm.count(processed);
    var maxSubstring = Algrorithm.Algrorithm.getMaxSubstring(processed);
    var withoutSybmol = (new Algrorithm.Async()).deleteRandomSymbol(processed);
    

    Console.Write(processed);
    Console.Write(count);
    Console.WriteLine($"\nНаибольшая подстрока {maxSubstring}");

    Console.WriteLine("Введите 0 или любой другой символ (qSort или TreeSort) для выбора способа сортировки");
    input = Console.ReadLine();
    if (input != "0") 
        Console.WriteLine($"Отсортированная строка методом TreeSort {Algrorithm.Algrorithm.treeSort(processed)}");
    else
        Console.WriteLine($"Отсортированная строка методом qSort {Algrorithm.Algrorithm.quickSort(processed)}");

    Console.WriteLine($"Строка без случайного символа: {await withoutSybmol}");

    
} catch (Exception ex) {
    Console.WriteLine(ex.Message);
}