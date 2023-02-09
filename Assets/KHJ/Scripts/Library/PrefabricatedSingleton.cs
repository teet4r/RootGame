using UnityEngine;

/// <summary>
/// 하이어라키에 존재해야하는 싱글턴
/// </summary>
/// <typeparam name="T"></typeparam>
public class PrefabricatedSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get { return _instance; }
    }
    static T _instance = null;

    protected virtual void Awake()
    {
        // 하이어라키에 이미 만들어진 경우 실행
        if (_instance == null)
        {
            _instance = this as T;
            name = typeof(T).ToString();
            DontDestroyOnLoad(_instance);
        }
        else
            Destroy(gameObject);
    }
    protected virtual void OnApplicationQuit()
    {
        Time.timeScale = 0f;
    }
}