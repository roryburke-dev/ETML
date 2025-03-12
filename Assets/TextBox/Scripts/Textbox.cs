using System;
using UnityEngine;
using UnityEngine.UI;

namespace TextBox.Scripts
{
    public class Textbox : MonoBehaviour
    {
        private Image _image;
        private ICell[,] _cells; //[row][column]

        private void Awake()
        {
            _cells = new ICell[,] { };
        }

        public void ChangeImageSprite(Sprite sprite)
        {
            if (sprite == null) return;
            _image ??= GetComponent<Image>();
            _image.sprite = sprite;
        }

        //Do before setting individual ICells!!!!!
        public void SetCells(ICell[,] cells)
        {
            _cells = cells;
        }

        public ICell[,] GetCells()
        {
            return _cells;
        }

        public void SetCell(ICell cell, Vector2 pos)
        {
            _cells[(int)pos.x,(int)pos.y] = cell;
        }

        public ICell GetCell(Vector2 pos)
        {
            return _cells[(int)pos.x,(int)pos.y];
        }
    }
}
