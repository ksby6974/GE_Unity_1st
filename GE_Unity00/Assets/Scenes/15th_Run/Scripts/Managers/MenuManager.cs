using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text [] texts;
    [SerializeField] int fontSize;
    [SerializeField] int fontSizeSelected;
    [SerializeField] int iOrder;
    [SerializeField] int iLimit;
    [SerializeField] bool bStart;

    void Awake()
    {
        bStart = false;
        fontSize = 72;
        fontSizeSelected = 96;
        iOrder = 0;
        iLimit = 3;
        texts[0].text = "START";
        texts[1].text = "SHOP";
        texts[2].text = "QUIT";
        Select_Button(iOrder);
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }

    public void Selected(int n)
    {
        if ((bStart == true) && (iOrder == n))
        {
            switch (n)
            {
                case 0:
                    Execute();
                    break;

                case 1:
                    Shop();
                    break;

                case 2:
                    Quit();
                    break;

                default:
                    break;
            }
        }

        bStart = true;
        iOrder = n;
        Select_Button(iOrder);
    }

    void Select_Button(int value)
    {
        for (int i = 0; i < iLimit; i++)
        {
            texts[i].fontSize = this.fontSize;
        }

        texts[value].fontSize = this.fontSizeSelected;
    }

    public void Execute()
    {
        StartCoroutine(ScManager.Instance.AsyncLoad(1));
    }

    public void Shop()
    {
        Debug.Log($"Shop");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
