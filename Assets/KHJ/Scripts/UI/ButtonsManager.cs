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
        AllyFish.MiniFish_RB,
        AllyFish.GoldFish,
        AllyFish.BurntFish_RB,
        AllyFish.TaiyakiFish_RB,
        AllyFish.AgariFish_RB
    };
    public readonly AllyFish[] custardCreams =
    {
        AllyFish.MiniFish_CC,
        AllyFish.GoldFish,
        AllyFish.BurntFish_CC,
        AllyFish.TaiyakiFish_CC,
        AllyFish.AgariFish_CC
    };
    
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        // 임시로 설정
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
