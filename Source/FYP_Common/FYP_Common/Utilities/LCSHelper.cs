using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYP_Common
{
    public class LCSHelper
    {
        public static int GetLCS(string str1, string str2)
        {
            int[,] table;
            return GetLCSInternal(str1, str2, out table);
        }

        private static int GetLCSInternal(string str1, string str2, out int[,] matrix)
        {
            matrix = null;

            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return 0;
            }

            int[,] table = new int[str1.Length + 1, str2.Length + 1];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                table[i, 0] = 0;
            }
            for (int j = 0; j < table.GetLength(1); j++)
            {
                table[0, j] = 0;
            }

            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        table[i, j] = table[i - 1, j - 1] + 1;
                    else
                    {
                        if (table[i, j - 1] > table[i - 1, j])
                            table[i, j] = table[i, j - 1];
                        else
                            table[i, j] = table[i - 1, j];
                    }
                }
            }

            matrix = table;
            return table[str1.Length, str2.Length];
        }

        public StringBuilder ReadLCSFromBacktrack(int[,] backtrack, string string1, string string2, int s1position, int s2posision)
        {
            if ((s1position < 0) || (s2posision < 0))
            {
                return new StringBuilder();
            }
            else if (string1[s1position] == string2[s2posision])
            {
                return ReadLCSFromBacktrack(backtrack, string1, string2, s1position - 1, s2posision - 1).Append(string1[s1position]);
            }
            else
            {
                if (backtrack[s1position, s2posision - 1] >= backtrack[s1position - 1, s2posision])
                {
                    return ReadLCSFromBacktrack(backtrack, string1, string2, s1position, s2posision - 1);
                }
                else
                {
                    return ReadLCSFromBacktrack(backtrack, string1, string2, s1position - 1, s2posision);
                }
            }
        }
    }
}
