using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunnerUIManager : MonoBehaviour
{
    [SerializeField] float TotalScore;
    [SerializeField] float CurrentScore;
    [SerializeField] TextMeshProUGUI textTScore;
    [SerializeField] TextMeshProUGUI textCScore;

    void Awake()
    {
        TotalScore = 0;
        CurrentScore = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scoring();
    }

    void Scoring()
    {
        CurrentScore += 100 * Time.deltaTime;
        
        textCScore.text = $"Score : {CurrentScore.ToString("F0")}";
    }
}
