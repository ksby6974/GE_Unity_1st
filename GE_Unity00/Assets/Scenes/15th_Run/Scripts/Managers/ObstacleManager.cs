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

            // 현재 게임 오브젝트가 활성화되어 있는가 확인
            while (obstacles[iRandom].activeSelf == true)
            {
                //현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는가 확인
                if (ExamineActive())
                {
                    // 모든 게임 오브젝트가 활성화되어있다면 게임 오브젝트를 새로 생성한 다음 obstalces 리스트에 삽입
                    GameObject clone = ResourcesManager.Instance.Instantiate("Coin", gameObject.transform);
                    clone.SetActive(false);
                    obstacles.Add(clone);
                }

                //현재 리스트에 있는 모든 게임 오브젝트가 비활성화 상태라면 random 변수의 값을 +1해서 재검색
                iRandom = (iRandom + 1) % obstacles.Count;

                if (iCount > iLimit)
                {
                    Debug.Log($"ActiveObstacle : Infinity Loop Cancle");
                    break;
                }
                else
                {
                    iCount++;
                    Debug.Log($"ActiveObstacle : {iCount}번 반복 / 임의{iRandom}");
                }
            }

            // 랜덤으로 설정된 Obstalce 오브젝트를 활성화
            obstacles[iRandom].SetActive(true);
        }
    }

    IEnumerator OnObstacle()
    {
        int iTemp = 0;
        int iRandomA = Random.Range(0,5);
        int iRandomB = iRandomA + Random.Range(0, 5);
        Debug.Log($"OnObstacle : {iRandomA} ~ {iRandomB} / 【{iCount}】");

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
