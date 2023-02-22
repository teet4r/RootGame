using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayChecker : MonoBehaviour, ICustomUpdate
{
    PointerEventData pointer = new(null);
    List<RaycastResult> raycastResults = new();
    [SerializeField] bool isCardSelected = false;
    [SerializeField] Card firstSelectedCard;
    [SerializeField] Card secondSelectedCard;

    private void OnEnable()
    {
        RegisterCustomUpdate();
    }
    private void Start()
    {
        SoundManager.Instance.BgmAudio.Play(Bgm.CardGame);
    }
    public void CustomUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointer.position = Input.mousePosition;
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0 && raycastResults[0].gameObject.GetComponent<Card>())
            {
                SoundManager.Instance.SfxAudio.Play(Sfx.CardSelect);
                Card tmpCard = raycastResults[0].gameObject.GetComponent<Card>();
                if (tmpCard.Playing)
                {
                    raycastResults.Clear();
                    return;
                }
                if (isCardSelected)
                {
                    if (firstSelectedCard == tmpCard)
                    {
                        raycastResults.Clear();
                        return;
                    }
                    secondSelectedCard = tmpCard;
                    if (firstSelectedCard.Num / 2 == secondSelectedCard.Num / 2)
                    {
                        SoundManager.Instance.SfxAudio.Play(Sfx.CardSuccess);
                        firstSelectedCard.DestroyCard(0f);
                        secondSelectedCard.OpenCard(true);
                    }
                    else
                    {
                        SoundManager.Instance.SfxAudio.Play(Sfx.CardFail);
                        firstSelectedCard.CloseCard();
                        secondSelectedCard.CloseCard();
                    }
                    Debug.Log(firstSelectedCard.name);
                    Debug.Log(secondSelectedCard.name);
                    isCardSelected = false;
                }
                else
                {
                    firstSelectedCard = tmpCard;
                    firstSelectedCard.OpenCard(false);
                    isCardSelected = true;
                }
            }
            raycastResults.Clear();
        }
    }
    private void OnDisable()
    {
        DeregisterCustomUpdate();
    }

    public void RegisterCustomUpdate()
    {
        CustomUpdateManager.Instance.RegisterCustomUpdate(this);
    }
    public void DeregisterCustomUpdate()
    {
        CustomUpdateManager.Instance.DeregisterCustomUpdate(this);
    }
}