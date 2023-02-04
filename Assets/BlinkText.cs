using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkText : MonoBehaviour
{
    public float time;
    Text text;
    Color color;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(BlinkTest());
    }
    IEnumerator BlinkTest()
    {
        while (true)
        {
            text.text = "";
            yield return new WaitForSeconds(.5f);
            text.text = "Tap to Start";
            yield return new WaitForSeconds(.5f);
        }
    }

}
