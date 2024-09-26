using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : State
{
    [SerializeField] int iCount = 10;
    [SerializeField] List<GameObject> listroads;
    [SerializeField] float fSpeed;
    [SerializeField] float offset;
    [SerializeField] SpeedManager speedManager;

    // Start is called before the first frame update
    void Start()
    {
        //fSpeed = 6.0f;
        offset = 40f;
        listroads.Capacity = 10;
        AddRoad();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == false)
        {
            return;
        }

        fSpeed = speedManager.Speed;

        for (int i = 0; i < iCount; i++)
        {
            if (listroads[i] != null)
                listroads[i].transform.Translate(Vector3.back * fSpeed * Time.deltaTime);
        }
    }

    void AddRoad()
    {
        for (int i = 0; i < iCount; i++)
        {
            listroads.Add(transform.GetChild(i).gameObject);
        }
    }

    public void NewPosition()
    {
        Debug.Log($"RoadManager - NewPosition");

        GameObject newRoad = listroads[0];
        listroads.Remove(newRoad);

        float newZ = listroads[listroads.Count - 1].transform.position.z + offset;
        newRoad.transform.position = new Vector3(newRoad.transform.position.x, newRoad.transform.position.y, newZ);
        listroads.Add(newRoad);
    }
}
