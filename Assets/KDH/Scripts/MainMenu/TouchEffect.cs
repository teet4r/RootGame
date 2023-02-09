using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchEffect : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float destroyTime;
    Image image;
    Transform tr;
    private void Start()
    {
        tr = GetComponent<Transform>();
        image = GetComponent<Image>();
        image.color = new Color(0.4f + Random.Range(0f, 0.6f), 0.4f + Random.Range(0f, 0.6f), 0.4f + Random.Range(0f, 0.6f));
        Destroy(this.gameObject, destroyTime);
        tr.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));
        float size = Random.Range(0.25f, 1.25f);
        tr.localScale = new Vector3(size, size, size);
        StartCoroutine(PlayTouchEffect());
    }

    IEnumerator PlayTouchEffect()
    {
        Color color = image.color;
        while (true)
        {
            color.a -= 0.02f / destroyTime;
            image.color = color;
            tr.Translate(Vector2.up * 0.02f * moveSpeed, Space.Self);
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }
}