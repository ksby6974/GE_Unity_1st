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
    [SerializeField] int iRandom;

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
        Create();
        StartCoroutine(ActiveObstacle());
    }

    void Create()
    {
        for (int i = 0; i < iCount; i++)
        {
           // obstalcePrefab = ResourcesManager.Instantiate(Cone, this.gameObject.transform);
            obstalcePrefab = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);
            obstalcePrefab.SetActive(false);
            obstacles.Add(obstalcePrefab);
        }

        Debug.Log($"CreateObstacle End");
    }

    IEnumerator ActiveObstacle()
    {
        int iLimit = 10000;
        int iCount = 0;

        while (true)
        {
            yield return CoroutineCache.waitForSeconds(2.5f);

            iRandom = Random.Range(0, obstacles.Count);

            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ°� Ȯ��
            while (obstacles[iRandom].activeSelf == true)
            {
                //���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ°� Ȯ��
                if (ExamineActive())
                {
                    // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ��ִٸ� ���� ������Ʈ�� ���� ������ ���� obstacles ����Ʈ�� ����
                    GameObject Clone = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);
                    Clone.SetActive(false);
                    obstacles.Add(Clone);
                }

                //���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� ��Ȱ��ȭ ���¶�� random ������ ���� +1�ؼ� ��˻�
                iRandom = (iRandom + 1) % obstacles.Count;

                //Debug.Log($"ActiveObstacle : {iCount}�� �ݺ� > {iLimit} / ���� {iRandom}, ī��Ʈ{obstacles.Count}");
                if (iCount > iLimit)
                {
                    Debug.Log($"ActiveObstacle : Infinity Loop Cancle");
                    break;
                }
                else
                {
                    iCount++;
                }
            }

            // �������� ������ Obstalce ������Ʈ�� Ȱ��ȭ
            obstacles[iRandom].SetActive(true);
            Debug.Log($"obstacles {iRandom}��° Ȱ��ȭ");
        }
    }

    public bool ExamineActive()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }

    public GameObject GetObstacle()
    {
        return obstacles[iRandom];
    }
}
