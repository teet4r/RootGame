using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleEffect : MonoBehaviour
{
    [SerializeField] float destroyTime;
    [SerializeField] float moveSpeed;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(0.4f + Random.Range(0f, 0.6f), 0.4f + Random.Range(0f, 0.6f), 0.4f + Random.Range(0f, 0.6f));
        float size = Random.Range(0.25f, 1.5f);
        Destroy(this.gameObject, destroyTime);
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));
        transform.localScale = new Vector3(size, size, size);
        StartCoroutine(PlayEffect());
    }
    IEnumerator PlayEffect()
    {
        Color color = image.color;
        while (true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed, Space.Self);
            color.a -= Time.deltaTime / destroyTime;
            image.color = color;
            yield return null;
        }
    }
}