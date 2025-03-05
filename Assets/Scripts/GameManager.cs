using ETML;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TextManager _textManager;
    
    private void Awake() 
    {
        if (gameObject)
        {
            _textManager = gameObject.AddComponent<TextManager>();
        }
    }
}
