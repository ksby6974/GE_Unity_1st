using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    private int iCount = 0;
    private int iLimit = 5;
    [SerializeField] GameObject [] prefabs;
    [SerializeField] GameObject cloneObject;

    void Awake()
    {
        ;
    }

    // Start is called before the first frame update
    void Start()
    {
        iCount = 0;
        iLimit = 5;
        StartCoroutine(CreateObject_Crt());
    }

    // Update is called once per frame
    private void Update()
    {
        //fTime = CreateTimer(fTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
           Destroy(cloneObject);
        }
    }

    // ÄÚ·çÆ¾
    IEnumerator CreateObject_Crt()
    {
        while (iCount < iLimit)
        {
            float fRandomX = Random.Range(-3, 3);
            float fRandomY = Random.Range(-3, 3);
            cloneObject = Instantiate(prefabs[iCount++]);
            cloneObject.transform.position = new Vector3(fRandomX, fRandomY, 1);
            Debug.Log($"Coroutine:{iCount}£¨{fRandomX},{fRandomY}£©");


            yield return new WaitForSeconds(3f);
        }
    }
}
