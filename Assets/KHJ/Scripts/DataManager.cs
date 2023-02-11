using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    public CharacterData[] datas = null;
    public CostText costText = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
