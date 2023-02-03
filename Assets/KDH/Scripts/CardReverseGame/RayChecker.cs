using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayChecker : MonoBehaviour
{
    PointerEventData pointer = new PointerEventData(null);
    List<RaycastResult> raycastResults = new();
    bool isCardSelected = false;
    Card firstSelectedCard;
    Card secondSelectedCard;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0 && raycastResults[0].gameObject.GetComponent<Card>())
            {
                if (isCardSelected)
                {
                    if (firstSelectedCard == raycastResults[0].gameObject.GetComponent<Card>())
                    {
                        raycastResults.Clear();
                        return;
                    }
                    secondSelectedCard = raycastResults[0].gameObject.GetComponent<Card>();
                    firstSelectedCard.UnSelectCard();
                    secondSelectedCard.UnSelectCard();
                    if (firstSelectedCard.Num / 2 == secondSelectedCard.Num / 2)
                    {
                        firstSelectedCard.CheckCard(true);
                        secondSelectedCard.CheckCard(true);
                    }
                    else
                    {
                        firstSelectedCard.CheckCard(false);
                        secondSelectedCard.CheckCard(false);
                    }
                    firstSelectedCard = null;
                    secondSelectedCard = null;
                    isCardSelected = false;
                }
                else
                {
                    firstSelectedCard = raycastResults[0].gameObject.GetComponent<Card>();
                    firstSelectedCard.SelectCard();
                    isCardSelected = true;
                }
            }
            raycastResults.Clear();
        }
    }
}