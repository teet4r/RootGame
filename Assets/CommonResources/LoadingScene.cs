using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;

    [SerializeField] GameObject[] loadingGroups;
    [SerializeField] Image[] images;
    [SerializeField] float loadingTime;
    [SerializeField] int sceneNum = 0;
    [SerializeField] bool check = true;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (check)
        {
            check = false;
            SetSceneNum();
        }
    }

    void SetSceneNum()
    {
        sceneNum = LoadingSceneManager.instance.sceneNum;
        for (int i = 0; i < loadingGroups.Length; i++)
        {
            if (loadingGroups[i].transform.GetSiblingIndex() + 1 == sceneNum)
            {
                loadingGroups[i].SetActive(true);
                StartCoroutine(FillLoadingBar());
                continue;
            }
            loadingGroups[i].SetActive(false);
        }
    }

    IEnumerator FillLoadingBar()
    {
        float fillAmount = 0f;
        while (true)
        {
            if (fillAmount >= 1.25f)
            {
                check = true;
                SceneManager.LoadScene(sceneNum);
            }
            images[sceneNum - 1].fillAmount = fillAmount;
            fillAmount += Time.deltaTime / loadingTime;
            yield return null;
        }
    }
}