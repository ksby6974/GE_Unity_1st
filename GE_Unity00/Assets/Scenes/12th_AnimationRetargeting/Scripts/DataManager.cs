using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] int TotalScore;
    [SerializeField] int upScore;
    [SerializeField] TextMeshProUGUI textTotalScore;
    [SerializeField] TextMeshProUGUI textUpScore;
    [SerializeField] UI_Score scoreUI;

    // Start is called before the first frame update
    void Awake()
    {
        TotalScore = 0;
        upScore = 0;
        Load();
    }

    public void Update()
    {
        textTotalScore.text = $"Score : {TotalScore}";

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScore();
        }
    }

    public void IncreaseScore()
    {
        upScore = Random.Range(5,11);
        int iTemp = upScore;

        if (upScore > 0)
        {
            textUpScore.text = $"+ {upScore}";
        }
        else
        {
            textUpScore.text = null;
        }

        TotalScore += upScore;

        scoreUI.OnUpdate(iTemp);
        PlayerPrefs.SetInt("Score", TotalScore);
    }

    public void Load()
    {
        TotalScore = PlayerPrefs.GetInt("Score");
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Score", TotalScore);
    }

    public void ResetScore()
    {
        TotalScore = 0;
        Save();
    }
}
