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


        private void ParseText()
        {
            path = "Assets/Scripts/ETML/Utils/Parser/Data/" + path;
            Debug.Log(path);
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