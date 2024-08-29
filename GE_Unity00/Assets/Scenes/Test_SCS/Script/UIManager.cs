using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    bool bGame = true;
    [SerializeField] GameObject obj_sys;
    [SerializeField] int iLife;
    [SerializeField] float fTime;

    [SerializeField] Button [] buttonArray;
    int Buttonindex;
    [SerializeField] TextMeshProUGUI TextPro_Timer;
    [SerializeField] TextMeshProUGUI TextPro_Life;
    [SerializeField] TextMeshProUGUI TextPro_Result;


    // Start is called before the first frame update
    void Start()
    {
        Buttonindex = -1;
        iLife = 3;
        fTime = 60f;
        TextPro_Timer.text = $"{fTime}";
    }

    // Update is called once per frame
    void Update()
    {
        if (bGame == true)
        {
            ShowUI();
        }

        if (iLife == 0 || fTime <= 0)
        {
            bGame = false;
            ShowGameOver();
        }
    }

    void ShowUI()
    {
        TextPro_Life.text = $"Life : {iLife}";

        fTime -= 1f * Time.deltaTime;
        TextPro_Timer.text = fTime.ToString("F2");
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
