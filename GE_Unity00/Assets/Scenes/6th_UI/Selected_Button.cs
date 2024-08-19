using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected_Button : MonoBehaviour
{
    [SerializeField] GameObject obj_Select;

    public void OnEnter()
    {
        Debug.Log("On");
        obj_Select.SetActive(true);
    }

    public void OnExit()
    {
        Debug.Log("Off");
        obj_Select.SetActive(false);
    }
}
