using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Algrorithm {
public static class Algrorithm {

private static void qSort(Array input) {
    Array.Sort(input);
}

public static string? flipAndDuplex(string? input) {
    if (input == null) return null;
    var output = new string("");
    var tempArrayOutput = input.ToCharArray();
    var extend = new string("");

    for (int i = 0; i < tempArrayOutput.Length; i++) 
        if ((tempArrayOutput[i] < 'a') || (tempArrayOutput[i] > 'z')) 
            extend += $"Неверный символ \"{tempArrayOutput[i]}\" на позиции {i+1}\n";
    if (extend.Length != 0) throw new Exception(extend); 

    if (input.Length % 2 == 0) {
        Array.Reverse(tempArrayOutput, 0, tempArrayOutput.Length / 2);
        Array.Reverse(tempArrayOutput, tempArrayOutput.Length / 2, tempArrayOutput.Length / 2);
        output = new string(tempArrayOutput);
    } else {
        Array.Reverse(tempArrayOutput);
        output = new string(tempArrayOutput) + input;
    }

    extend = output + extend;

    int[] chars = new int['z' - 'a' + 1];
    foreach(var i in output) chars[i - 'a']++;
    for (char i = 'a'; i <= 'z'; i++) {
        if (chars[i - 'a'] == 0) continue;
        extend += $"\nсимвол {i} всречался в обработанной строке {chars[i - 'a']} раз";
    }

    var first = output.IndexOfAny("eyuioa".ToCharArray());
    var tmp = output.ToCharArray();
    Array.Reverse(tmp);
    var second = new string(tmp).IndexOfAny("eyuioa".ToCharArray());
    string maxSubString = output.Substring(first, tmp.Length - second - first);

    extend += $"\nНаибольшая подстрока {maxSubString}";

    return extend;
}  
}
}