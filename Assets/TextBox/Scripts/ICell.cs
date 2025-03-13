using TMPro;
using UnityEngine;

namespace TextBox.Scripts
{
    public interface ICell 
    {
        public char Letter { get; set; }
        public TMP_Text Text { get; set; }
        public Vector2 Position { get; set; }
        public bool Active { get; set; }
    }
}
