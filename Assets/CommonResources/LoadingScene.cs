using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour, ICustomUpdate
{
    public static LoadingScene instance = null;

    [SerializeField] GameObject[] loadingGroups;
    [SerializeField] Image[] images;
    [SerializeField] float loadingTime;
    [SerializeField] int sceneNum = 0;
    [SerializeField] bool check = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SoundManager.Instance.BgmAudio.Stop();
    }

    private void OnEnable()
    {
        RegisterCustomUpdate();
    }
    public void CustomUpdate()
    {
        if (check)
        {
            check = false;
            SetSceneNum();
        }
    }
    private void OnDisable()
    {
        DeregisterCustomUpdate();
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

    public void RegisterCustomUpdate()
    {
        CustomUpdateManager.Instance.RegisterCustomUpdate(this);
    }
    public void DeregisterCustomUpdate()
    {
        CustomUpdateManager.Instance.DeregisterCustomUpdate(this);
    }
}