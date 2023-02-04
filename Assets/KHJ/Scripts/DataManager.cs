using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    public CharacterData[] allyDatas = null;
    public CharacterData[] enemyDatas = null;

    public AllyController allyController = null;
    public EnemyController enemyController = null;

    public Transform allyHomeTr = null;
    public Transform enemyHomeTr = null;

    public CostText costText = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void MakeAllyFish(int buttonIndex)
    {
        var data = allyDatas[(int)ButtonsManager.instance.redBeanButtonArray[buttonIndex]];
        var remainCost = costText.curCost - data.Cost;
        if (remainCost < 0)
            return;

        costText.UpdateCost(remainCost);
        var clone = Instantiate(allyController);
        clone.transform.position = allyHomeTr.position;
        clone.SpriteRenderer.sprite = data.Sprite;
        clone.SpriteRenderer.color = data.Color;
        clone.Transform.eulerAngles = data.Rotation;
    }
    public void MakeEnemyFish(int buttonIndex)
    {
        var data = enemyDatas[(int)ButtonsManager.instance.redBeanButtonArray[buttonIndex]];
        var clone = Instantiate(enemyController);
        clone.transform.position = enemyHomeTr.position;
        clone.SpriteRenderer.sprite = data.Sprite;
        clone.SpriteRenderer.color = data.Color;
        clone.Transform.eulerAngles = data.Rotation;
    }
}
