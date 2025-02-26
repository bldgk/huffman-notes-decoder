using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Threading;

namespace HuffmanLibrary
{
    public class Huffman
    {
        public Huffman()
        {

        }

        public Huffman(Dictionary<char, string> codeCombinations)
        {
            codeCombinations.ToList().ForEach(p => CodeCombinations.Add(p.Key, p.Value));
        }

        public Huffman(string alphabet)
        {
            Alphabet = alphabet;
            MakeEnsemble();
            MakeTableAndTree();
            MakeCodeCombination();
        }

        string Alphabet { get; set; }

        public Collection<Symbol> Ensemble { get; private set; } = new Collection<Symbol>();

        public Collection<ICollection<Symbol>> ProbabilityTable { get; private set; } = new Collection<ICollection<Symbol>>();

        public TreeNode Tree
        {
            get
            {
                return ProbabilityTable.Last().First();
            }
        }

        public Dictionary<char, string> CodeCombinations { get; private set; } = new Dictionary<char, string>();

        public void SetAlphabet(string newAlphabet)
        {
            Alphabet = newAlphabet;
            MakeEnsemble();
            MakeTableAndTree();
            MakeCodeCombination();
        }

        public string Encode(string text)
        {
            string encodedText = string.Empty;
            text.ToList().ForEach(p =>
            {
                try
                {
                    encodedText += CodeCombinations[p];
                }
                catch { }
            });
            return encodedText;
        }

        public string Decode(string text)
        {
            string decodedtext = string.Empty;
            Queue<char> charsInText = new Queue<char>();
            text.ToList().ForEach(p => charsInText.Enqueue(p));
            string token = charsInText.Dequeue().ToString();
            Dictionary<string, char> reversedCodeCombinations = ReversePolarity(CodeCombinations);
            while (charsInText.Count()>=0)
            {
                if (reversedCodeCombinations.ContainsKey(token))
                {
                    decodedtext += reversedCodeCombinations[token];
                    if (charsInText.Count > 0)
                    {
                        token = charsInText.Dequeue().ToString();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    token += charsInText.Dequeue().ToString();
                }
            }
            return decodedtext;
        }
        
        public void SetEnsemble(Collection<Symbol> newEnsemble)
        {
            Ensemble = newEnsemble;
        }

        public void MakeEnsemble()
        {
            HashSet<char> charsInText = new HashSet<char>();
            //Dictionary<char, int> Entries = new Dictionary<char, int>();
            Alphabet.ToList().ForEach(p => charsInText.Add(p));
            //CharsInText.ToList().ForEach(p => Entries.Add(p, new Regex(p.ToString()).Matches(Text).Count));
            //Entries.ToList().ForEach(p => Ensemble.Add(new Probability((double)p.Value / (double)Text.Count(), p.Key)));
            //Ensemble = Ensemble.OrderByDescending(o => o.Value).ToList();
            charsInText.ToList().ForEach(p => Ensemble.Add(new Symbol(p, new Regex(p.ToString()).Matches(Alphabet).Count)));
            // Ensemble = Ensemble.OrderBy(o => o.Frequency).ToList();
        }

        public void MakeTableAndTree()
        {
			Queue<Symbol> currentQueue = new Queue<Symbol>();
            Ensemble.OrderBy(o => o.Frequency).ToList().ForEach(p => currentQueue.Enqueue(p));
            ProbabilityTable.Add(currentQueue.ToList());
            while (currentQueue.Count > 1)
            {
                var newNode = new Symbol(currentQueue.Dequeue(), currentQueue.Dequeue());
                var temporaryQueue = currentQueue.ToList();
                if (currentQueue.Count == 0)
                {
                    currentQueue.Enqueue(newNode);
                }
                else
                {
                    int index = 0;
                    currentQueue.ToList().ForEach(p =>
                    {
                        if (newNode.Frequency <= p.Frequency)
                        {
                            index = currentQueue.ToList().IndexOf(p);
                        }
                        else
                        {
                            index++;
                        }
                    });
                    temporaryQueue.Insert(index, newNode);
                    currentQueue.Clear();
                    temporaryQueue.ForEach(p => currentQueue.Enqueue(p));
                }
                ProbabilityTable.Add(currentQueue.ToList());
            }
        }

        public void MakeCodeCombination()
        {
            ((Symbol)Tree).TraverseTree(string.Empty);
            Symbol.CodeCombinations.ToList().ForEach(p => CodeCombinations.Add(p.Key, p.Value));
        }
        
        public Dictionary<string,char>ReversePolarity(Dictionary<char,string>collection)
        {
            var temporaryCollection = new Dictionary<string, char>();
            collection.ToList().ForEach(p =>
            {
                temporaryCollection.Add(p.Value, p.Key);
            });
            return temporaryCollection;
        }
    }
}
    