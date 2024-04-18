

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GamingOS.OsAsm
{
    public class Compiler
    {
        public List<string> Lines;

        public void MergeContentToLines(string content)
        {
            Lines.AddRange(content.Split('\n'));
        }
        public byte[] Compile()
        {
            List<byte> ret = new List<byte>();
            List<string> words = new List<string>();
            foreach (string line in Lines)
            {
                List<string> split = new List<string>();
                int index = 0;
                while(index < line.Length)
                {
                    string cur = "";
                    while (char.IsLetter(line[index]) || char.IsDigit(line[index]))
                    {
                        cur += line[index].ToString();
                        index++;
                    }
                    if (cur.Length > 0)
                    {
                        words.Add(cur);
                    }
                }
            }
            return ret.ToArray();
        }
    }
}
