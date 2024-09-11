using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScManager : MonoBehaviour
{
    [SerializeField] Image image_fade;

    void Awake()
    {
        // ���� �Ѿ�� DontDestroyOnLoad �޸𸮿� �ش� ������Ʈ�� ��� ��������
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator FadeIn()
    {
        //Color cTemp = new Color();
        Color cTemp = image_fade.color;
        cTemp.a = 1;
        image_fade.gameObject.SetActive(true);
        while (cTemp.a > 0)
        {
            cTemp.a -= 0.1f * Time.deltaTime;
            image_fade.color = cTemp;
        }
        image_fade.gameObject.SetActive(false);

        yield break;
    }

    public IEnumerator AsyncLoad(int index)
    {
        image_fade.gameObject.SetActive(true);

        // asyncOperation.allowSceneActivation
        // ����� �غ�� ��� ����� Ȱ��ȭ�Ǵ� ���� ���
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        Color color = image_fade.color;
        color.a = 0f;

        // asyncOperation.isDone
        // �ش� ������ �Ϸ�Ǿ������� ��Ÿ���� ���� (�б� ����)
        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;
            image_fade.color = color;

            // asyncOperation.progress
            // �۾��� ���� ���¸� ��Ÿ���� ���� (�б� ����)
            if (asyncOperation.progress >- 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);
                image_fade.color = color;

                if (color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;
                    yield break;
                }
            }

            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene(1);

            StartCoroutine(AsyncLoad(1));
        }
    }

    void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        // Fade in ȣ��
        Debug.Log($"Fade In");
        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
