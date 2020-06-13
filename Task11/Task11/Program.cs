using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class Program
    {
        public static string Code(string str,ref Dictionary<char, string> dictCode, ref Dictionary<string, char> dictEncode)
        {
            int iter = 10;
            dictCode = new Dictionary<char, string>();
            dictEncode = new Dictionary<string, char>();
            for (int i = 0; i < str.Length; ++i)
            {
                if (dictCode.ContainsKey(str[i]) == false)
                {
                    dictCode.Add(str[i], iter.ToString());
                    dictEncode.Add(iter.ToString(), str[i]);
                    iter++;
                }
            }
            string code = "";
            for (int i = 0; i < str.Length; ++i)
            {
                code += dictCode[str[i]];
            }
            return code;
        }
        public static string Encode(string code, ref Dictionary<char, string> dictCode, ref Dictionary<string, char> dictEncode)
        {
            string encode = "";
            for (int i = 0; i < code.Length; i += 2)
            {
                string tmp = code[i].ToString() + code[i + 1].ToString();
                encode += dictEncode[tmp];
            }
            return encode;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string str = Console.ReadLine();
            Dictionary<char, string> dictCode = new Dictionary<char, string>();
            Dictionary<string, char> dictEncode = new Dictionary<string, char>();
            string code = Code(str, ref dictCode, ref dictEncode);
            foreach (var tmp in dictCode)
                Console.WriteLine($"Ключ символа {tmp.Key} - {tmp.Value}");
            
            Console.WriteLine("Зашифрованная последовательсность");
            Console.WriteLine(code);
            string encode = Encode(code, ref dictCode, ref dictEncode);
            Console.WriteLine("Дешифрованная последовательсность");
            Console.WriteLine(encode);
        }
    }
}
