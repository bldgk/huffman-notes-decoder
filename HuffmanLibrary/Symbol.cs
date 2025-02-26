using System;
using System.Collections.Generic;

namespace HuffmanLibrary
{
    public class Symbol : TreeNode
    {
        public static Dictionary<char, string> CodeCombinations { get; } = new Dictionary<char, string>();
        public Symbol()
        {

        }

        public Symbol(char value, int frequency)
        {
            Value = value;
            Frequency = frequency;
        }

        public Symbol(Symbol firstTerm, Symbol secondTerm)
        {
            if (firstTerm == null || secondTerm == null)
            {
                throw new ArgumentNullException("firstTerm");
            }
            Frequency = firstTerm.Frequency + secondTerm.Frequency;
            if (firstTerm?.Frequency > secondTerm?.Frequency)
            {
                RightChild = firstTerm;
                LeftChild = secondTerm;
            }
            else
            {
                LeftChild = firstTerm;
                RightChild = secondTerm;
            }
        }

        public char Value { get; set; }

        public int Frequency { get; set; }

        public void TraverseTree(string code)
        {
            if (LeftChild == null || RightChild == null)
            {
                Symbol.CodeCombinations.Add(Value, code);
            }

            ((Symbol)LeftChild)?.TraverseTree(code + "0");
            ((Symbol)RightChild)?.TraverseTree(code + "1");
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Value, Frequency);
        }
    }
}
