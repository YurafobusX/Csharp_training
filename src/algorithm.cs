using System.Numerics;
using System.Text.Json;

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


public static void check(in string input, in IList<string> blacklist) {
    if (blacklist.Contains(input)) throw new Exception("Слово в чёрном списке");
    var output = new string("");
    var temp = input.ToCharArray();
        for (int i = 0; i < temp.Length; i++) 
            if ((temp[i] < 'a') || (temp[i] > 'z')) 
                output += $"Неверный символ \"{temp[i]}\" на позиции {i+1}\n";
    if (output.Length != 0) throw new Exception(output); 
}

public static int[] count(in string input) {
    int[] chars = new int['z' - 'a' + 1];
    foreach(var i in input) chars[i - 'a']++;
    return chars;
}

public static string getMaxSubstring(in string input) {
    try {
        var first = input.IndexOfAny("eyuioa".ToCharArray());
        var tmp = input.ToCharArray();
        Array.Reverse(tmp);
        var second = new string(tmp).IndexOfAny("eyuioa".ToCharArray());
        return input.Substring(first, tmp.Length - second - first);
    } catch (System.ArgumentOutOfRangeException) {
        return "";
    }
}
}

class Async {
public async Task<string> deleteRandomSymbol(string input, string api) {
    var rand = 0;

    try {
        var json = JsonDocument.Parse(await (new HttpClient()).GetStringAsync($"{api}/random?min=0&max={input.Length}&count=1"));
        rand = json.RootElement[0].GetInt32();
    } catch (Exception) {
        rand = (new Random()).Next(input.Length);
    }
    
    return input.Remove(rand, 1);
}
}
}