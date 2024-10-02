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
            //GameObject obstalcePrefab = ResourcesManager.Instantiate(Cone, this.gameObject.transform);
            obstalcePrefab = ResourcesManager.Instance.Instantiate("Cone", this.gameObject.transform);
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
            yield return CoroutineCache.waitForSeconds(2f);

            iRandom = Random.Range(0, obstacles.Count);

            // 현재 게임 오브젝트가 활성화되어 있는가 확인
            while (obstacles[iRandom].activeSelf == true)
            {
                //현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는가 확인
                if (ExamineActive())
                {
                    // 모든 게임 오브젝트가 활성화되어있다면 게임 오브젝트를 새로 생성한 다음 obstalces 리스트에 삽입
                    GameObject Clone = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);
                    Clone.SetActive(false);
                    obstacles.Add(Clone);
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
                    Debug.Log($"ActiveObstacle : {iCount}번 반복 / 임의 {iRandom}, 카운트{obstacles.Count}");
                }
            }

            // 랜덤으로 설정된 Obstalce 오브젝트를 활성화
            obstacles[iRandom].SetActive(true);
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
}
