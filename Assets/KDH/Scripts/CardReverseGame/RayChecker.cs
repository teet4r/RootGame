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

    private void Start()
    {
        SoundManager.Instance.BgmAudio.Play(Bgm.CardGame);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0 && raycastResults[0].gameObject.GetComponent<Card>())
            {
                StartCoroutine(PlaySound(Sfx.CardSelect, 0f));
                if (raycastResults[0].gameObject.GetComponent<Card>().Playing)
                {
                    raycastResults.Clear();
                    return;
                }
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
                        StartCoroutine(PlaySound(Sfx.CardSuccess, 0.6f));
                        firstSelectedCard.CheckCard(true);
                        secondSelectedCard.CheckCard(true);
                    }
                    else
                    {
                        StartCoroutine(PlaySound(Sfx.CardFail, 0.6f));
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

    IEnumerator PlaySound(Sfx _sfx, float _time)
    {
        yield return new WaitForSeconds(_time);
        SoundManager.Instance.SfxAudio.Play(_sfx);
        yield break;
    }
}