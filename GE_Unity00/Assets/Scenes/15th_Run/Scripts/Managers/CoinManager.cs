using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject Coins;
    [SerializeField] float fSpeed;
    [SerializeField] float fOffset;
    [SerializeField] int iCount;

    void Awake()
    {
        iCount = 16;
        fSpeed = 2.5f;
        fOffset = 2.5f;
    }

    void Start()
    {
        CreateCoin();
    }

    void CreateCoin()
    {
        for (int i = 0; i < iCount; i++)
        {
            GameObject coin = Instantiate(Coins);
            coin.transform.SetParent(gameObject.transform);

            float newZ = coin.transform.position.z + (fOffset * i);
            coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y, newZ);
            coin.transform.localPosition = new Vector3(0, 0.1f, fOffset * i);
        }
    }
}
