using System.Collections;
using TMPro;
using UnityEngine;

public class FrameText : MonoBehaviour
{
    [SerializeField] float refreshTime;
    TMP_Text frameText;
    WaitForSeconds waitRefreshTime;

    private void Start()
    {
        frameText = GetComponent<TMP_Text>();
        waitRefreshTime = new WaitForSeconds(refreshTime);
        StartCoroutine(RefreshFrameText());
    }

    IEnumerator RefreshFrameText()
    {
        while(true)
        {
            frameText.text = $"fps {(int)(1f / Time.deltaTime)}";
            yield return waitRefreshTime;
        }
    }
}