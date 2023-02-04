using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadChicken : MonoBehaviour
{
    public void LoadChick()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    
}
