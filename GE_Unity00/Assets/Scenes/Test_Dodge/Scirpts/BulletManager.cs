using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject[] patternList;

    [Header("Current Pattern Info")]
    [SerializeField] int patternIndex = 0;
    [SerializeField] GameObject currentPattern;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeBullet());

        foreach (GameObject pattern in patternList)
        {
            pattern.gameObject.SetActive(false);
        }

        ChangePattern();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPattern()
    {
        if (currentPattern.activeSelf == false)
        {
            ChangePattern();
        }
    }

    public void ChangePattern()
    {
        currentPattern = patternList[patternIndex];
        currentPattern.SetActive(true);

        patternIndex += 1;

        if (patternIndex >= patternList.LongLength)
        {
            patternIndex = 0;
        }
    }

    IEnumerator MakeBullet()
    {
        Debug.Log($"ÄÚ·çÆ¾");

        int iCount = 3;

        while (iCount > 0)
        {
            float fTemp = Random.Range(0,360);

            for (int i = 0; i < 12; i++)
            {
                fTemp = i * 30;

                GameObject cloneBullet = Instantiate(bulletPrefab, gameObject.transform);

                cloneBullet.transform.SetParent(gameObject.transform);

                cloneBullet.GetComponent<Bullet>().SetBullet(1f, fTemp);
            }

            iCount -= 1;
        }

        yield return null;
    }
}
