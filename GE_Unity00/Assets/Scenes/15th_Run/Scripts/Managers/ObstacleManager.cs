using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject obstalcePrefab;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] int iCount;
    [SerializeField] float fOffset;
    [SerializeField] float fPositionX;

    // Start is called before the first frame update
    void Awake()
    {
        iCount = 10;
        fOffset = 2.5f;
        fPositionX = 4f;
        obstacles.Capacity = iCount;
    }

    void Start()
    {
        Create(obstalcePrefab);
    }

    void Create(GameObject gObject)
    {
        Debug.Log($"Test");

        for (int i = 0; i < iCount; i++)
        {
            obstalcePrefab = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);

            obstalcePrefab.transform.SetParent(gameObject.transform);

            float newZ = obstalcePrefab.transform.position.z + (fOffset * i);
            obstalcePrefab.transform.position = new Vector3(obstalcePrefab.transform.position.x, obstalcePrefab.transform.position.y, newZ);
            obstalcePrefab.transform.localPosition = new Vector3(0, 0.1f, fOffset * i);

            int iIndex = obstalcePrefab.name.IndexOf("(Clone)");

            if (iIndex > 0)
            {
                obstalcePrefab.name = obstalcePrefab.name.Substring(0, iIndex);
            }

            obstalcePrefab.GetComponent<MeshRenderer>().enabled = false;

            this.obstalcePrefab.SetActive(false);
            obstacles.Add(obstalcePrefab);
        }
    }
}
