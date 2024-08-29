using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    int iLimit = 5;
    [SerializeField] int[] iKillArray;
    [SerializeField] int iCheck;
    [SerializeField] GameObject[] obj;

    // Start is called before the first frame update
    void Start()
    {
        iKillArray = new int[2];
        iCheck = -1;
        ResetKillArray();
    }

    public void ResetKillArray()
    {
        for (int i = 0; i < 2; i++)
        {
            iKillArray[i] = -1;
        }
    }

    public void OnBlock(int type)
    {
        Debug.Log($"OnBlock : {type}");

        if (iCheck >= 0)
        {
            //정답
            if (iCheck == type)
            {
                Debug.Log($"정답");

                Debug.Log($"왜 리셋? {iKillArray[0]}, {iKillArray[1]}");
                Destroy(obj[iKillArray[0]]);
                Destroy(obj[iKillArray[1]]);
                iLimit -= 1;

                GameObject.Find("UIManager").GetComponent<UIManager>().ShowGameClear(iLimit);
            }
            else
            {
                GameObject.Find("UIManager").GetComponent<UIManager>().LostLife();
                Debug.Log($"오답");
            }

            iCheck = -1;
            ResetKillArray();
        }
        else
        {
            iCheck = type;
        }
    }

    public void ReadyKill(int index)
    {
        Debug.Log($"Test:{index}, {iKillArray[0]}, {iKillArray[1]}");

        for (int i = 0; i < 2; i++)
        {
            if (iKillArray[i] == -1)
            {
                Debug.Log($"KillReady = {iKillArray[i]}");
                iKillArray[i] = index;
                break;
            }
        }
    }
}