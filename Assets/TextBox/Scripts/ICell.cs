using TMPro;
using UnityEngine;

namespace TextBox.Scripts
{
    public interface ICell 
    {
        public char Letter { get; set; }
        public TextMeshPro Text { get; set; }
        public Vector2 Position { get; set; }
    }
}
