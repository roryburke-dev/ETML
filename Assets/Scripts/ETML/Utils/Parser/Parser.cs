using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ETML.Utils.Parser
{
    public static class Parser
    {
        [MenuItem("Tools/Parse Text File")]
        private static void ParseTextFile()
        {
            const string path = "Assets/Scripts/ETML/Utils/Parser/Data/TextFile.txt";
            var data = File.ReadAllText(path);
            var charData = data.ToCharArray();
            var wordData = data.Split(new char[] { ' ', '.', ',', ';', '?', '!', '/' });
            var csvData = data.Split(',');
            foreach (var word in wordData)
            {
                Debug.Log(word);
            }
        }
    }
}