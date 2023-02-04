using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingProgress : MonoBehaviour
{

    [SerializeField]
    Sprite[] loadImgs;
    [SerializeField]
    Image progressBar;
    [SerializeField]
    Image loadingScreenImg;
    int sceneNum;

    void Start()
    {
        sceneNum = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        loadingScreenImg.sprite = loadImgs[sceneNum]; //���� ��� ���� ��ư�� �ε��� ��������
        StartCoroutine(LoadSceneProgress());
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneNum+1);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime / 3f; //���� �ʸ�ŭ ����
                progressBar.fillAmount = Mathf.Lerp(0f, 1f, timer);
                if (timer > 1)
                {
                    timer = 1;
                }

                if (progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
