using System;
using UnityEngine;

namespace TextBox.Scripts
{
    public class TextboxController : MonoBehaviour
    {
        public Transform cellPrefab;
        private Textbox _textbox;
        private Transform _textboxTransform;
        private string _testText; //Delete!!
        public char[] _testChars; //Delete!!

        private void Start()
        {
            _testText = "This is a test";
            _testChars = _testText.ToCharArray();
        }

        public void SetTextbox(Textbox textbox)
        {
            _textbox = textbox;
        }

        public void SetTextInTextbox(char[] letters)
        {
            int h = 0;
            for (int i =0; i < _textbox.GetCells().GetLength(0); i++ )
            {
                for (int j = 0; j < _textbox.GetCells().GetLength(1); j++)
                {
                    if (h < letters.Length)
                    {
                        var cell = Instantiate(cellPrefab).GetComponent<Cell>();
                        cell.Init(letters[h], new Vector2(i, j));
                        _textbox.SetCell(cell, new Vector2(i, j));
                        h++;
                    }
                }   
            }
        }

        public Textbox GetTextbox()
        {
            return _textbox;
        }
    }
}
