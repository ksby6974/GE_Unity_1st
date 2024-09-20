using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject Coin;
    [SerializeField] List<GameObject> Coins;

    [SerializeField] float fSpeed;
    [SerializeField] float fOffset;
    [SerializeField] int iCount;
    [SerializeField] float fPositionX;

    void Awake()
    {
        iCount = 16;
        fSpeed = 2.5f;
        fOffset = 2.5f;
        fPositionX = 4f;
        Coins.Capacity = iCount;
    }

    void Start()
    {
        CreateCoin();
    }

    void CreateCoin()
    {
        for (int i = 0; i < iCount; i++)
        {
            GameObject clone = Instantiate(Coin);
            clone.transform.SetParent(gameObject.transform);

            float newZ = clone.transform.position.z + (fOffset * i);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, newZ);
            clone.transform.localPosition = new Vector3(0, 0.1f, fOffset * i);

            int iIndex = clone.name.IndexOf("(Clone)");

            if (iIndex > 0)
            {
                clone.name = clone.name.Substring(0, iIndex);
            }

            //clone.gameObject.SetActive(false);
            Coins.Add(clone);
        }
    }

    public void InitializePosition()
    {
        Debug.Log($"InitializePosition");
        transform.localPosition = new Vector3(fPositionX * Random.Range(-1, 2), 0, 0);

        for (int i = 0; i < iCount; i++)
        {
            //Coins[i].gameObject.SetActive(true);
            Debug.Log($"{i}");
        }
    }
}
