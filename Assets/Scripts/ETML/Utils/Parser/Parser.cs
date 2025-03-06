using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace ETML.Utils.Parser
{
    public class Parser : EditorWindow
    {
        private string path;
        
        [MenuItem("Tools/Parse Text File")]
        private static void ParseTextFile()
        {
            EditorWindow.GetWindow(typeof(Parser));
        }
        
        public void CreateGUI()
        {
            path = "Assets/ETML/Utils/Parser/Data/";
            // Each editor window contains a root VisualElement object
            var root = rootVisualElement;
            
            var fileTextField = new TextField("Text File:");
            fileTextField.name = "TextFile";
            root.Add(fileTextField);

            // Create button
            var button = new Button();
            button.name = "button";
            button.text = "Submit";
            button.clicked += ParseText;
            root.Add(button);
        }

        public void OnGUI()
        { 
            path = rootVisualElement.Q<TextField>("TextFile").text + ".txt";
        }

        private string fileText;

        private void ParseText()
        {
            fileText = ReadText();
            var charArray = fileText.ToCharArray();
            if (CheckIfEMTL())
            {
                int j = 1000000;
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i] == '[')
                    {
                        j = i;
                    }
                }

                if (charArray[j + 1] == 'A')
                {
                    //Change to red
                    Debug.Log("Red");
                }
                
                else if (charArray[j + 1] == 'D')
                {
                    //Change to blue
                    Debug.Log("Blue");
                }
            }
            else
            {
                Debug.Log("Error!");
            }
        }

        private string ReadText()
        {
            return File.ReadAllText(GetFullPath());
        }

        private char[] ConvertFileToCharArray(string text)
        {
            return text.ToCharArray();
        }

        private string[] ConvertFileToWordArray(string text)
        {
            return text.Split(' ');
        }

        private string GetFullPath()
        {
            return "Assets/Scripts/ETML/Utils/Parser/Data/" + path;
        }

        private bool CheckIfEMTL()
        {
            var charArray = ConvertFileToCharArray(fileText);
            var result = false;
            foreach (var c in charArray)
            {
                if (c == '[')
                {
                    result = true;
                }

                if (c == ']' && result == false)
                {
                    return false;
                }
            }
            return result;
        }
    }
}