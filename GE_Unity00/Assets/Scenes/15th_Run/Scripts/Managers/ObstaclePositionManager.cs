using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePositionManager : MonoBehaviour
{
    [SerializeField] int iIndex;
    [SerializeField] bool bState = false;
    [SerializeField] Transform[] parentRoad;
    [SerializeField] Transform randomPosition;
    [SerializeField] float[] randomPositionZ;
    [SerializeField] ObstacleManager obstacleManager;

    [SerializeField] Transform[] PositionX;

    void Awake()
    {
        randomPositionZ = new float[16];

        for (int i = 0; i < randomPositionZ.Length; i++)
        {
            randomPositionZ[i] = i * 2.5f + (-10.0f);
        }
    }

    void Start()
    {
        iIndex = -1;
        transform.SetParent(parentRoad[0]);
        StartCoroutine(SetPosition());
    }

    public void InitializePosition()
    {
        bState = true;

        iIndex = (iIndex + 1) % parentRoad.Length;

        transform.SetParent(parentRoad[iIndex]);

        transform.localPosition = new Vector3(0, 0, 40);
    }

    private IEnumerator SetPosition()
    {
        while (true)
        {
            yield return CoroutineCache.waitForSeconds(2.5f);

            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0, randomPositionZ.Length)]);

            if (bState == true)
            {
                obstacleManager.GetObstacle().SetActive(true);

                obstacleManager.GetObstacle().transform.position = transform.localPosition;

                obstacleManager.GetObstacle().transform.position = PositionX[Random.Range(0, PositionX.Length)].position;

                obstacleManager.GetObstacle().transform.SetParent(transform.root.GetChild((iIndex + 1) % parentRoad.Length));
            }
        }
    }
}
