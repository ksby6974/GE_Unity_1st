using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{
    [SerializeField] Text[] buttonText;
    [SerializeField] string[] buttonTextNames;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonText.Length; i++)
        {
            buttonText[i].text = buttonTextNames[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Active_NewGame()
    {
        Debug.Log("New Game");
    }

    public void Active_Continue()
    {
        Debug.Log("Continue");
    }

    public void Active_Exit()
    {
        Debug.Log("Exit");
    }
}
