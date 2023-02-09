using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static LoadingSceneManager instance;
    public int sceneNum = -1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadScene(int _num)
    {
        sceneNum = _num;
        if (_num >= 1 && _num <= 3)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(_num);
        }
    }
}