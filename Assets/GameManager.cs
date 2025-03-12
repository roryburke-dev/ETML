using System;
using ETML;
using ETML.Model;
using TextBox.Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Letter letterTest;
    public Text text;
    public Transform textbox;
    
    private TextboxController _textboxController;
    private Textbox _textbox;
    
    private TextManager _textManager;
    
    
    private void Awake() 
    {
        if (gameObject)
        {
            _textManager = gameObject.AddComponent<TextManager>();
        }
        if(textbox)
        {
            _textboxController = textbox.GetComponent<TextboxController>();
            _textbox = textbox.GetComponent<Textbox>();
            _textboxController.SetTextbox(_textbox);
            _textboxController.GetTextbox().SetCells(new ICell[5,28]);
        }
    }

    private float growingNumber;
    private int count;
    
    private void Update()
    {
        growingNumber += Time.deltaTime;
        //letterTest.SetScale(growingNumber, growingNumber, 0);
        if (Input.GetKeyDown(KeyCode.B))
        {
            letterTest.ChangeColor(EColor.Blue);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            letterTest.ChangeColor(EColor.Red);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count > 4)
            {
                count = 0;
            }

            Debug.Log(text.data[count].text);
            count++;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (_textboxController.GetTextbox() != null)
            {
                var testText = "This is a test";
                var testChars = testText.ToCharArray();
                _textboxController.SetTextInTextbox(testChars);
                foreach (var letter in _textboxController.GetTextbox().GetCells())
                {
                    if (letter != null)
                    {
                        Debug.Log(letter.Letter);
                    }
                }
            }
            /*
            foreach (var letter in _textboxController.GetTextbox().GetCells())
            {
                Debug.Log(letter.Letter);
            }
            */
        }
    }
}
