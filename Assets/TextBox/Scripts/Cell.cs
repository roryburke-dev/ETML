using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TextBox.Scripts
{
    public class Cell : MonoBehaviour, ICell
    {
        public char Letter { get; set; }
        public TMP_Text Text { get; set; }
        public Vector2 Position { get; set; }
        public bool Active { get; set; }
        private Transform _child;
        
        public void Init(char letter,Vector2 position)
        {
            _child = transform.GetChild(0);
            Letter = letter;
            Position = position;
            Text = _child.GetComponent<TMP_Text>();
            Text.text = letter.ToString();
            Active = true;
        }

        public void ChangeLetter(char letter)
        {
            Letter = letter;
            Text.text = letter.ToString();
        }
    }
    
}
