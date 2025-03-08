using System;
using ETML;
using ETML.Model;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TextManager _textManager;
    public Letter letterTest;
    public Text text;
    
    private void Awake() 
    {
        if (gameObject)
        {
            _textManager = gameObject.AddComponent<TextManager>();
        }
    }

    private float growingNumber;
    private int count;
    
    private void Update()
    {
        growingNumber += Time.deltaTime;
        letterTest.SetScale(growingNumber, growingNumber, 0);
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
    }
}
