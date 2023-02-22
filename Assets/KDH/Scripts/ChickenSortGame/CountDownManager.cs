using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] GameObject textStart;
    [SerializeField] float time;
    WaitForSeconds waitTime;

    private void Start()
    {
        waitTime = new WaitForSeconds(time);
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        yield return waitTime;
        text3.SetActive(true);
        yield return waitTime;
        text2.SetActive(true);
        yield return waitTime;
        text1.SetActive(true);
        yield return waitTime;
        textStart.SetActive(true);
        yield return waitTime;
        ChickenManager.instance.GameStart();
    }
}