using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public static ButtonsManager instance = null;

    [SerializeField] Text[] _fishCostTexts = null;
    [SerializeField] Image[] _fishImages = null;

    // 팥 순서, 슈크림 순서가 정해져 있음
    public readonly AllyFish[] redBeans =
    {
        AllyFish.BurntFish_RB,
        AllyFish.MiniFish_RB,
        AllyFish.GoldFish,
        AllyFish.TaiyakiFish_RB,
        AllyFish.AgariFish_RB
    };
    
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        SetButtons(redBeans);
    }

    public void SetButtons(params AllyFish[] fishes)
    {
        for (int i= 0; i < fishes.Length; i++)
        {
            var data = DataManager.instance.allyDatas[(int)fishes[i]];
            _fishImages[i].sprite = data.Sprite;
            _fishCostTexts[i].text = $"{data.Cost}";
        }
    }
}
