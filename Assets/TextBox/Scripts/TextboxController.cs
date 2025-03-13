using System;
using TMPro;
using UnityEngine;

namespace TextBox.Scripts
{
    public class TextboxController : MonoBehaviour
    {
        public Transform cellPrefab;
        private Textbox _textbox;
        private Transform _textboxTransform;
        private float _offset;

        private void Awake()
        {
            _offset = 3.5f;
        }

        public void SetTextbox(Textbox textbox)
        {
            _textbox = textbox;
            _textboxTransform = textbox.transform;
        }

        // Origin = (-600, 100, 0), Offset = (40,-40,0)
        public void SetTextInTextbox(char[] letters)
        {
            var h = 0;
            for (var i =0; i < 5; i++ )
            {
                for (var j = 0; j < 28; j++)
                {
                    if (h <= letters.Length - 1)
                    {
                        var cell = Instantiate(cellPrefab).GetComponent<Cell>();
                        cell.transform.SetParent(_textboxTransform, false);
                        cell.transform.localPosition = new Vector3(-45, 7, 0);
                        if (h != 0)
                        {
                            cell.transform.localPosition = new Vector3
                            (
                                cell.transform.localPosition.x + (_offset * j),
                                cell.transform.localPosition.y + (_offset * -i),
                                cell.transform.localPosition.z
                            );
                        }
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
