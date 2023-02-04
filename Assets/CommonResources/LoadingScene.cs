using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;

    [SerializeField] GameObject[] loadingGroups;
    [SerializeField] Image[] images;
    [SerializeField] float loadingTime;
    int sceneNum = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetSceneNum();
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
                SceneManager.LoadScene(sceneNum);
            }
            images[sceneNum - 1].fillAmount = fillAmount;
            fillAmount += Time.deltaTime / loadingTime;
            yield return null;
        }
    }
}