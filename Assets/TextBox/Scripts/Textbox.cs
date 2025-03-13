using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TextBox.Scripts
{
    public class Textbox : MonoBehaviour
    {
        private Image _image;
        private List<ICell> _cells; //[row][column]

        private void Awake()
        {
            _cells = new List<ICell>();
        }

        public void ChangeImageSprite(Sprite sprite)
        {
            if (sprite == null) return;
            _image ??= GetComponent<Image>();
            _image.sprite = sprite;
        }

        //Do before setting individual ICells!!!!!
        public void SetCells(List<ICell> cells)
        {
            _cells = cells;
        }

        public List<ICell> GetCells()
        {
            return _cells.Cast<ICell>().Where(cell => cell.Active).ToList();
        }

        public void SetCell(ICell cell, Vector2 pos)
        {
            cell.Position = pos;
            _cells.Add(cell);
        }

        public ICell GetCell(Vector2 pos)
        {
            return _cells[(int)((pos.x * 28) + pos.y)];
        }
    }
}
