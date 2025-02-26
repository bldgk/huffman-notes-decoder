using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Security.Cryptography;

namespace HuffmanLibrary
{
    [DataContract]
    public class Settings
    {
        [DataMember]
        public byte[] AlphabetHash { get; set; } = new byte[] { };

        public string Alphabet { get; set; }

        public Dictionary<char,string> LoadCodeCombinations()
        {
            try
            {
                DataContractSerializer xmls = new DataContractSerializer(typeof(Dictionary<char, string>));
                XmlReader xmlr = XmlReader.Create("CodeCombinations.xml");
                Dictionary<char, string> x = (Dictionary<char, string>)xmls.ReadObject(xmlr);
                xmlr.Close();
                return x;
            }
            catch
            {
                return null;
            }
        }

        public void SaveCodeCombinations(Dictionary<char, string>  savingCodeCombinations)
        {
            try
            {
                DataContractSerializer xmls = new DataContractSerializer(typeof(Dictionary<char, string>));
                XmlWriter xmlw = XmlWriter.Create("CodeCombinations.xml");
                xmls.WriteObject(xmlw, savingCodeCombinations);
                xmlw.Close();
            }
            catch
            {

            }
        }

        public static Settings Load()
        {
            try
            {
                DataContractSerializer xmls = new DataContractSerializer(typeof(Settings));
                XmlReader xmlr = XmlReader.Create("Settings.xml");
                Settings x = (Settings)xmls.ReadObject(xmlr);
                xmlr.Close();
                return x;
            }
            catch { return null; }
        }

        public static void Save(Settings savedSettins)
        {                   
            try
            {
                
                DataContractSerializer xmls = new DataContractSerializer(typeof(Settings));
                XmlWriter xmlw = XmlWriter.Create("Settings.xml");
                xmls.WriteObject(xmlw, savedSettins);
                xmlw.Close();
            }
            catch { }
        }

        public void LoadAlphabet()
        {
            try
            {
                using (StreamReader file = new StreamReader(@"Alphabet.txt"))
                {
                    Alphabet = file.ReadLine();
                }
            }
            catch
            {
            }
        }

        public void SaveAlphabet()
        {
            using (StreamWriter file = new System.IO.StreamWriter(@"Alphabet.txt"))
            {
                file.WriteLine(Alphabet);
            }
            using (MD5 md5 = MD5.Create())
            {
                AlphabetHash = md5.ComputeHash(Alphabet.ToUTF8());
            }
        }

        public bool CheckAlphabet()
        {
            var md5 = MD5.Create();
            if (AlphabetHash.SequenceEqual(md5.ComputeHash(Alphabet.ToUTF8())))
                return true;
            else return false;
        }
    }
}
