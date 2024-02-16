using System.Numerics;
using System.Runtime.CompilerServices;

namespace Algrorithm {
public static class Algrorithm {

public static string? flipAndDuplex(string? input) {
    if (input == null) return null;
    var output = input.ToCharArray();
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