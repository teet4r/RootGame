using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButtonGroup : MonoBehaviour
{
    [SerializeField] float movingTime;
    [SerializeField] float spacingY;
    GridLayoutGroup gridLayoutGroup;
    private void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        StartCoroutine(MoveDownButtons());
    }

    IEnumerator MoveDownButtons()
    {
        float num = gridLayoutGroup.spacing.y - spacingY;
        while (true)
        {
            if (gridLayoutGroup.spacing.y - num * Time.deltaTime / movingTime >= spacingY)
            {
                gridLayoutGroup.spacing = new Vector2(0f, spacingY);
                yield break;
            }
            gridLayoutGroup.spacing -= new Vector2(0f, num * Time.deltaTime / movingTime);
            yield return null;
        }
    }
}