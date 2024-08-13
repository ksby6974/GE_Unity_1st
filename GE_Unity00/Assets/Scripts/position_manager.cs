using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_manager : MonoBehaviour
{
    [SerializeField] Transform [] spawners;
    [SerializeField] GameObject obj_aircraft;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ResetPosition",5);
        InvokeRepeating("ResetPosition", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void ResetPosition()
    {
        int random = Random.Range(0, spawners.Length);
        Debug.Log(spawners[random].position);

        obj_aircraft.transform.position = new Vector3(spawners[random].position.x, spawners[random].position.y, spawners[random].position.z);
    }
}
