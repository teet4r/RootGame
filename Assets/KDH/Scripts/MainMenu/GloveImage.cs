using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveImage : MonoBehaviour
{
    [SerializeField] RectTransform blueGlove;
    [SerializeField] RectTransform redGlove;
    [SerializeField] GameObject spark;
    [SerializeField] float moveBoomSpeed;
    [SerializeField] float moveAwaySpeed;
    [SerializeField] float boomXPos;
    [SerializeField] float awayXPos;
    float yPos;

    private void Start()
    {
        yPos = blueGlove.anchoredPosition.y;
        if (TitleImageChecker.instance.isPlayed)
        {
            blueGlove.anchoredPosition = new Vector2(awayXPos, yPos);
            redGlove.anchoredPosition = new Vector2(-1f * awayXPos, yPos);
            spark.SetActive(true);
            return;
        }
        StartCoroutine(PlayGloveBoom());
    }

    IEnumerator PlayGloveBoom()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (blueGlove.anchoredPosition.x + Time.deltaTime * moveBoomSpeed >= boomXPos)
            {
                blueGlove.anchoredPosition = new Vector2(boomXPos, yPos);
                redGlove.anchoredPosition = new Vector2(-1 * boomXPos, yPos);
                spark.SetActive(true);
                StartCoroutine(PlayGloveAway());
                yield break;
            }
            blueGlove.Translate(new Vector2(Time.deltaTime * moveBoomSpeed, 0f));
            redGlove.Translate(new Vector2(Time.deltaTime * moveBoomSpeed * -1f, 0f));
            yield return null;
        }
    }

    IEnumerator PlayGloveAway()
    {
        while (true)
        {
            if (blueGlove.anchoredPosition.x - Time.deltaTime * moveAwaySpeed <= awayXPos)
            {
                blueGlove.anchoredPosition = new Vector2(awayXPos, yPos);
                redGlove.anchoredPosition = new Vector2(awayXPos * -1f, yPos);
                yield break;
            }
            blueGlove.Translate(new Vector2(Time.deltaTime * moveAwaySpeed * -1f, 0f));
            redGlove.Translate(new Vector2(Time.deltaTime * moveAwaySpeed, 0f));
            yield return null;
        }
    }
}