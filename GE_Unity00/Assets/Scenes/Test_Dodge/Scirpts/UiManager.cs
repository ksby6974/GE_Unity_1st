using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] GameObject obj_player;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI TextPro_Timer;
    [SerializeField] TextMeshProUGUI TextPro_Life;
    [SerializeField] TextMeshProUGUI TextPro_Result;

    [SerializeField] bool bGame;
    [SerializeField] float fTime;
    [SerializeField] int iLife;

    void Awake()
    {
        fTime = 60f;
        bGame = true;
        iLife = 3;
        fTime = 60f;
        TextPro_Timer.text = $"{fTime}";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();

        if (iLife == 0 || fTime <= 0)
        {
            bGame = false;
            ShowGameOver();
        }
    }

    public void ShowUI()
    {
        if (bGame == false)
        {
            return;
        }

        fTime -= 1f * Time.deltaTime;
        TextPro_Timer.text = fTime.ToString("F2");
        TextPro_Life.text = $"Life : {iLife}";
    }

    public void SetGameOver()
    {
        bGame = false;
        Destroy(obj_player);
    }

    public void ShowGameClear(int i)
    {
        if (i == 0)
        {
            bGame = false;
            TextPro_Result.text = "Game Clear!";
        }
    }

    void ShowGameOver()
    {
        TextPro_Result.color = Color.red;
        TextPro_Result.text = "Game Over";
    }

    public void LostLife()
    {
        iLife -= 1;
    }
}
