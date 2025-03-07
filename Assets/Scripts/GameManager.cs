using System;
using ETML;
using ETML.Model;
using ETML.Utils.LinkedList;
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
    
    private void Update()
    {
        growingNumber += Time.deltaTime;
        letterTest.SetScale(growingNumber, growingNumber, 0);
        if (Input.GetKeyDown(KeyCode.B))
        {
            letterTest.ChangeColor(ENUMColor.Blue);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            letterTest.ChangeColor(ENUMColor.Red);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(text.data[0].text);
        }
    }
}
