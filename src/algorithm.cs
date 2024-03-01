using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Algrorithm {
public static class Algrorithm {

private class Tree {
        public Tree? left;
        public Tree? right;
        public char? key;

        public Tree(char? ch) {key = ch;}

        public override string ToString() {
            return left?.ToString() + key?.ToString() + right?.ToString();
        }

        public void insert(Tree input) {
            if (key == null) {this.key = input.key; this.left = input.left; this.right = input.right; return;} 
            if (input.key < this.key) {
                if (left == null) left = input; else left.insert(input);
            } else {
                if (right == null) right = input; else right.insert(input);
            }
        }
    };

public static string treeSort(in string input) {
    Tree tmp = new Tree(null);
    foreach(var i in input) tmp.insert(new Tree(i));
    return tmp.ToString();
}

// Сортирует от begin (включительно) до end (не включая)
private static void _quickSort (char[] input, int begin, int end) {
if (begin >= end-1) return;
int left = begin;
int right = end - 1;
char key = input[begin];
while (right > left) {
    if (input[right] >= key) {right--; continue;}
    if (input[left] < key) {left++; continue;}
    (input[right], input[left]) = (input[left], input[right]);
}
_quickSort(input, begin, left+1);
_quickSort(input, left+1, end);
}

public static string quickSort(in string input) {
    var tmp = input.ToCharArray();
    _quickSort(tmp, 0, tmp.Length);
    return new string(tmp);
}

public static string process(in string input) {
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


public static void check(in string input) {
    var output = new string("");
    var temp = input.ToCharArray();
        for (int i = 0; i < temp.Length; i++) 
            if ((temp[i] < 'a') || (temp[i] > 'z')) 
                output += $"Неверный символ \"{temp[i]}\" на позиции {i+1}\n";
    if (output.Length != 0) throw new Exception(output); 
}

public static string count(in string input) {
    var output = new string("");
    int[] chars = new int['z' - 'a' + 1];
    foreach(var i in input) chars[i - 'a']++;
    for (char i = 'a'; i <= 'z'; i++) {
        if (chars[i - 'a'] == 0) continue;
        output += $"\nсимвол {i} всречался в обработанной строке {chars[i - 'a']} раз";
    }
    return output;
}

public static string getMaxSubstring(in string input) {
    var first = input.IndexOfAny("eyuioa".ToCharArray());
    var tmp = input.ToCharArray();
    Array.Reverse(tmp);
    var second = new string(tmp).IndexOfAny("eyuioa".ToCharArray());
    return input.Substring(first, tmp.Length - second - first);
}

}
}