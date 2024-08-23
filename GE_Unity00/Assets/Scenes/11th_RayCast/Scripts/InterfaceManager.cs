using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IInteractable
{
    public void Interact()
    {

    }

    public void Activate()
    {
       
    }
}

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI showtext;

    public void Update()
    {
        showtext.text = "Category";
    }
}
