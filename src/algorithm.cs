using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Algrorithm {
public static class Algrorithm {

public static string? flipAndDuplex(string? input) {
    if (input == null) return null;
    var output = input.ToCharArray();
    var error = new string("");
    for (int i = 0; i < output.Length; i++) 
        if ((output[i] < 'a') || (output[i] > 'z')) 
            error += $"Неверный символ \"{output[i]}\" на позиции {i+1}\n";
    if (error.Length != 0) throw new Exception(error); 
    if (input.Length % 2 == 0) {
        Array.Reverse(output, 0, output.Length / 2);
        Array.Reverse(output, output.Length / 2, output.Length / 2);
        return new string(output);
    } else {
        Array.Reverse(output);
        return new string(output) + input;
    }
}  
}
}