using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TextBox.Scripts
{
    public class Cell : MonoBehaviour, ICell
    {
        public char Letter { get; set; }
        public TextMeshPro Text { get; set; }
        public Vector2 Position { get; set; }
        public void Init(char letter,Vector2 position)
        {
            Letter = letter;
            Position = position;
            Text = transform.GetChild(0).GetComponent<TextMeshPro>();
        }
    }
    
}
