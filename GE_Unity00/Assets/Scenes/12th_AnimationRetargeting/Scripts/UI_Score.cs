using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    public void OnUpdate(int random)
    {
        scoreText.text = "Score - " + random.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
