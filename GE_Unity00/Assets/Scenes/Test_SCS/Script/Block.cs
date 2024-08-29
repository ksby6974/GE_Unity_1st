using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] int iType;

    public int GetType()
    {
        return this.iType;
    }
}
