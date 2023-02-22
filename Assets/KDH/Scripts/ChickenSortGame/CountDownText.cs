using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownText : MonoBehaviour
{
    [SerializeField] float scaleSpeed;
    [SerializeField] float scaleTime;
    [SerializeField] float minScale;
    [SerializeField] float maxScale;
    float time = 0f;
    Transform tr;
    private void Start()
    {
        tr = transform;
        tr.localScale = new Vector3(minScale, minScale, minScale);
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        float _scale;
        while (true)
        {
            if (time >= scaleTime)
            {
                gameObject.SetActive(false);
                yield break;
            }
            _scale = scaleSpeed * Time.deltaTime;
            time += Time.deltaTime;
            tr.localScale += new Vector3(_scale, _scale, _scale);
            yield return null;
        }
    }
}