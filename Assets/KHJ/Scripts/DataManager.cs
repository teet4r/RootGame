using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    public CharacterData[] allyDatas = null;
    public CharacterData[] enemyDatas = null;
    public CostText costText = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
