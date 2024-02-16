using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Algrorithm {
public static class Algrorithm {

public static string? flipAndDuplex(string? input) {
    if (input == null) return null;
    var output = input.ToCharArray();
    var extend = new string("");
    for (int i = 0; i < output.Length; i++) 
        if ((output[i] < 'a') || (output[i] > 'z')) 
            extend += $"Неверный символ \"{output[i]}\" на позиции {i+1}\n";
    if (extend.Length != 0) throw new Exception(extend); 
    int[] chars = new int['z' - 'a' + 1];
    foreach(var i in output) chars[i - 'a']++;
    for (char i = 'a'; i <= 'z'; i++) extend += $"\n символ {i} всречался в изначальное строке {chars[i - 'a']} раз";
    if (input.Length % 2 == 0) {
        Array.Reverse(output, 0, output.Length / 2);
        Array.Reverse(output, output.Length / 2, output.Length / 2);
        return new string(output) + extend;
    } else {
        Array.Reverse(output);
        return new string(output) + extend;
    }
}  
}
}