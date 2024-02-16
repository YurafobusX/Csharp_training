using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Algrorithm {
public static class Algrorithm {

//private static void qSort(out Array input) {
    //Array.Sort(input);

//}

private static string process(in string input) {
    var temp = input.ToCharArray();
    if (input.Length % 2 == 0) {
        Array.Reverse(temp, 0, temp.Length / 2);
        Array.Reverse(temp, temp.Length / 2, temp.Length / 2);
        return new string(temp);
    } else {
        Array.Reverse(temp);
        return new string(temp) + input;
    }
}

public static string? flipAndDuplex(in string? input) {
    if (input == null) return null;
    var output = new string("");

    { var temp = input.ToCharArray();
        for (int i = 0; i < temp.Length; i++) 
            if ((temp[i] < 'a') || (temp[i] > 'z')) 
                output += $"Неверный символ \"{temp[i]}\" на позиции {i+1}\n";
        if (output.Length != 0) throw new Exception(output); 
    }

    var processed = process(input);

    output = processed;

    int[] chars = new int['z' - 'a' + 1];
    foreach(var i in processed) chars[i - 'a']++;
    for (char i = 'a'; i <= 'z'; i++) {
        if (chars[i - 'a'] == 0) continue;
        output += $"\nсимвол {i} всречался в обработанной строке {chars[i - 'a']} раз";
    }

    var first = processed.IndexOfAny("eyuioa".ToCharArray());
    var tmp = processed.ToCharArray();
    Array.Reverse(tmp);
    var second = new string(tmp).IndexOfAny("eyuioa".ToCharArray());
    string maxSubString = processed.Substring(first, tmp.Length - second - first);

    output += $"\nНаибольшая подстрока {maxSubString}";


    //extend += $"\nОтсортированная строка {}";

    return output;
}  
}
}