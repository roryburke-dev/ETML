using System;
using System.Collections.Generic;
using System.IO;
using ETML.Utils.LinkedList;
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
            GetWindow(typeof(Parser));
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
           // path = rootVisualElement.Q<TextField>("TextFile").text + ".txt";
        }

        private string fileText;
        private string parsedText;

        private void ParseText()
        {
            // Parse File
            path = "TextFile.txt";
            fileText = ReadText();
            var charArray = fileText.ToCharArray();
            var i = 0;
            var j = 0;
            var isStarting = false;
            var isCounting = false;
            var modifierStrings = new string[5];
            var textStrings = new string[5];
            foreach (var ch in charArray)
            {
                if (!isStarting)
                {
                    if (ch.CompareTo('[') == 0)
                    {
                        isStarting = true;
                    }

                    if (ch.CompareTo(']') == 0)
                    {
                        j++;
                    }
                }
                else 
                {
                    if (!isCounting)
                    {
                        if (ch.CompareTo(']') == 0)
                        {
                            isCounting = true;
                        }
                        else
                        {
                            modifierStrings[i] += ch;
                        }
                    }
                    else
                    {
                        if (ch.CompareTo(']') == 0)
                        {
                            isCounting = false;
                            isStarting = false;
                            i++;
                            j++;
                        }
                        else
                        {
                            if (ch.CompareTo('[') != 0 && ch.CompareTo('/') != 0)
                            {
                                textStrings[j] += ch;
                            }
                        }
                    }
                }
            }
            
            // Create Scriptable Objects
            var asset = ScriptableObject.CreateInstance<Text>();
            AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath("Assets/Scripts/ETML/Utils/Parser/Data/ScriptableObjects/Texts/Text.asset"));
            AssetDatabase.SaveAssets();

            var listOfData = new List<TextData>();
            var h = 0;
            foreach (var t in textStrings)
            {
                var dataAsset = ScriptableObject.CreateInstance<TextData>();
                AssetDatabase.CreateAsset(dataAsset, AssetDatabase.GenerateUniqueAssetPath("Assets/Scripts/ETML/Utils/Parser/Data/ScriptableObjects/TextData/Data.asset"));
                AssetDatabase.SaveAssets();
                
                dataAsset.modifier = ConvertModifierStringToEnum(modifierStrings[h]);
                dataAsset.text = t;
                
                listOfData.Add(dataAsset);
                
                h++;
            }

            asset.data = listOfData.ToArray();
            
            // Focus Window
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        
        private ENUMModifier ConvertModifierStringToEnum(string modifierStr)
        {
            return modifierStr switch
            {
                "ANG"  => ENUMModifier.Angry,
                "ECT"  => ENUMModifier.Ecstatic,
                "CON"  => ENUMModifier.Confused,
                "DEP"  => ENUMModifier.Depressed,
                "SCD"  => ENUMModifier.Scared,
                "TRD" => ENUMModifier.Tired,
                "REL" => ENUMModifier.Relieved,
                "BRD" => ENUMModifier.Bored,
                _ => ENUMModifier.None
            };
        }

        private Text CreateTextObj()
        {
            var textObj = CreateInstance<Text>();
            AssetDatabase.CreateAsset(textObj, "Assets/ETML/Utils/Parser/Data/ScriptableObjects/TextObj.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = textObj;
            return textObj;
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
            return "Assets/Scripts/ETML/Utils/Parser/Data/TextFiles/" + path;
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
                    return false; }
            } 
            return result;
        }
    }
}