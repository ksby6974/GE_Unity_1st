using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        prefab = Instantiate(Resources.Load<GameObject>("Pier"));
        prefab.transform.position = new Vector3(10,0,0);
        Debug.Log($"Instantiate : {prefab}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
