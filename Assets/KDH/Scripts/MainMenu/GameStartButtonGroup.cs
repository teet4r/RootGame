using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButtonGroup : MonoBehaviour
{
    [SerializeField] float movingTime;
    [SerializeField] float spacingY;
    [SerializeField] GameObject gameExitButton;
    GridLayoutGroup gridLayoutGroup;
    private void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        if (!TitleImageChecker.instance.isPlayed) StartCoroutine(MoveDownButtons());
        else
        {
            gridLayoutGroup.spacing = new Vector2(0f, spacingY);
            gameExitButton.SetActive(true);
        }
    }

    IEnumerator MoveDownButtons()
    {
        float num = gridLayoutGroup.spacing.y - spacingY;
        while (true)
        {
            if (gridLayoutGroup.spacing.y - num * Time.deltaTime / movingTime >= spacingY)
            {
                gridLayoutGroup.spacing = new Vector2(0f, spacingY);
                gameExitButton.SetActive(true);
                yield break;
            }
            gridLayoutGroup.spacing -= new Vector2(0f, num * Time.deltaTime / movingTime);
            yield return null;
        }
    }
}