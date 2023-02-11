using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public static ButtonsManager instance = null;

    [SerializeField] Text[] _fishCostTexts = null;
    [SerializeField] Image[] _fishImages = null;

    // 팥 순서, 슈크림 순서가 정해져 있음
    public readonly Prefab[] allyRedBeans =
    {
        Prefab.AllyMiniFish_RB,
        Prefab.AllyBurntFish_RB,
        Prefab.AllyGoldFish,
        Prefab.AllyTaiyakiFish_RB,
        Prefab.AllyAgariFish_RB
    };
    
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        SetButtons(allyRedBeans);
    }

    public void SetButtons(params Prefab[] allyFishes)
    {
        for (int i = 0; i < allyFishes.Length; i++)
        {
            var fishData = DataManager.instance.datas[(int)allyFishes[i]];
            _fishImages[i].sprite = fishData.Sprite;
            _fishCostTexts[i].text = $"{fishData.Cost}";
        }
    }
}
