using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButton : MonoBehaviour
{
    [SerializeField] AudioClip enterAudioClip;
    [SerializeField] Button button;
    [SerializeField] Text buttontext;

    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
        buttontext.fontSize = 72;
    }

    public void ChangeSize_Default()
    {
        buttontext.fontSize = 72;
    }

    // Update is called once per frame
    public void ChangeSize_Enter()
    {
        buttontext.fontSize = 96;

        AudioManager.Instance.Listen(enterAudioClip);
    }

    public void ChangeSize_Selected()
    {
        buttontext.fontSize = 96;
    }
}
