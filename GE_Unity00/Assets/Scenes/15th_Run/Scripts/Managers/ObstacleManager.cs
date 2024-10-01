using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
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
        //StartCoroutine(OnObstacle());
    }

    void Create()
    {
        Debug.Log($"Create Test");

        for (int i = 0; i < iCount; i++)
        {
            //GameObject obstalcePrefab = ResourcesManager.Instantiate(Cone, this.gameObject.transform);
            GameObject obstalcePrefab = ResourcesManager.Instance.Instantiate("Cone", this.gameObject.transform);

            obstalcePrefab.transform.SetParent(this.gameObject.transform);

            float newZ = obstalcePrefab.transform.position.z + (fOffset * i);
            obstalcePrefab.transform.position = new Vector3(obstalcePrefab.transform.position.x, obstalcePrefab.transform.position.y, newZ);
            obstalcePrefab.transform.localPosition = new Vector3(0, 0.1f, fOffset * i);

            int iIndex = obstalcePrefab.name.IndexOf("(Clone)");

            if (iIndex > 0)
            {
                obstalcePrefab.name = obstalcePrefab.name.Substring(0, iIndex);
            }

           // obstalcePrefab.GetComponent<MeshRenderer>().enabled = false;

            obstalcePrefab.SetActive(false);
            obstacles.Add(obstalcePrefab);
        }
    }

    IEnumerator ActiveObstacle()
    {
        int iLimit = 100;
        int iCount = 0;

        while (true)
        {
            yield return CoroutineCache.waitForSeconds(2f);

            iRandom = Random.Range(0, obstacles.Count);

            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ°� Ȯ��
            while (obstacles[iRandom].activeSelf == true)
            {
                //���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ°� Ȯ��
                if (ExamineActive())
                {
                    // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ��ִٸ� ���� ������Ʈ�� ���� ������ ���� obstalces ����Ʈ�� ����
                    GameObject clone = ResourcesManager.Instance.Instantiate("Coin", gameObject.transform);
                    clone.SetActive(false);
                    obstacles.Add(clone);
                }

                //���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� ��Ȱ��ȭ ���¶�� random ������ ���� +1�ؼ� ��˻�
                iRandom = (iRandom + 1) % obstacles.Count;

                if (iCount > iLimit)
                {
                    Debug.Log($"ActiveObstacle : Infinity Loop Cancle");
                    break;
                }
                else
                {
                    iCount++;
                    Debug.Log($"ActiveObstacle : {iCount}�� �ݺ� / ����{iRandom}");
                }
            }

            // �������� ������ Obstalce ������Ʈ�� Ȱ��ȭ
            obstacles[iRandom].SetActive(true);
        }
    }

    IEnumerator OnObstacle()
    {
        int iTemp = 0;
        int iRandomA = Random.Range(0,5);
        int iRandomB = iRandomA + Random.Range(0, 5);
        Debug.Log($"OnObstacle : {iRandomA} ~ {iRandomB} / ��{iCount}��");

        while (true)
        {
            if (iTemp >= iCount)
            {
                break;
            }

            yield return CoroutineCache.waitForSeconds(0.1f);

            if (obstacles[iTemp] != null)
            {
                if ((iRandomA > iTemp) || (iRandomB < iTemp))
                {
                    obstacles[iTemp].SetActive(true);
                }
            }

            iTemp++;
        }

        StartCoroutine(ResetObstacle());
    }

    IEnumerator ResetObstacle()
    {
        yield return CoroutineCache.waitForSeconds(2f);

        for (int i = 0; i < iCount; i++)
        {
            obstacles[i].SetActive(false);
        }

        StartCoroutine(OnObstacle());
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
}
