using System;
using System.Collections.Generic;

class Program
{
    // 1
    public static long Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }

    // 2
    public static int Fibonacci(int n)
    {
        if (n <= 1) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    // 3
    public static string ReverseString(string str)
    {
        if (str.Length == 0) return str;
        return str[str.Length - 1] + ReverseString(str.Substring(0, str.Length - 1));
    }

    // 4
    public static int SumArray(int[] arr, int n)
    {
        if (n <= 0) return 0;
        return SumArray(arr, n - 1) + arr[n - 1];
    }

    // 5
    public static int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }

    // 6 я супчик кушать
    public static bool IsPalindrome(string str)
    {
        if (str.Length <= 1) return true;
        if (str[0] != str[str.Length - 1]) return false;
        return IsPalindrome(str.Substring(1, str.Length - 2));
    }

    // 7 я покушала рассольник с уксусом, вкуснятина, хочу ещё
    public static void TowerOfHanoi(int n, char source, char target, char auxiliary)
    {
        if (n == 1)
        {
            Console.WriteLine($"Переместите диск 1 с {source} на {target}");
            return;
        }
        TowerOfHanoi(n - 1, source, auxiliary, target);
        Console.WriteLine($"Переместите диск {n} с {source} на {target}");
        TowerOfHanoi(n - 1, auxiliary, target, source);
    }

    // 8
    public static IList<IList<T>> Subsets<T>(IList<T> nums)
    {
        var result = new List<IList<T>>();
        Backtrack(result, new List<T>(), nums, 0);
        return result;
    }

    private static void Backtrack<T>(IList<IList<T>> result, IList<T> tempList, IList<T> nums, int start)
    {
        result.Add(new List<T>(tempList));
        for (int i = start; i < nums.Count; i++)
        {
            tempList.Add(nums[i]);
            Backtrack(result, tempList, nums, i + 1);
            tempList.RemoveAt(tempList.Count - 1);
        }
    }

    // 9
    public class Node
    {
        public int Value;
        public List<Node> Children;

        public Node(int value)
        {
            Value = value;
            Children = new List<Node>();
        }

        public Node DeepCopy()
        {
            Node newNode = new Node(Value);
            foreach (var child in Children)
            {
                newNode.Children.Add(child.DeepCopy());
            }
            return newNode;
        }
    }

    // 10
    public static IList<string> Permutations(string str)
    {
        var result = new List<string>();
        Permute(result, str.ToCharArray(), 0);
        return result;
    }

    private static void Permute(IList<string> result, char[] arr, int start)
    {
        if (start >= arr.Length)
        {
            result.Add(new string(arr));
            return;
        }
        for (int i = start; i < arr.Length; i++)
        {
            Swap(arr, start, i);
            Permute(result, arr, start + 1);
            Swap(arr, start, i); // backtrack
        }
    }

    private static void Swap(char[] arr, int i, int j)
    {
        char temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}