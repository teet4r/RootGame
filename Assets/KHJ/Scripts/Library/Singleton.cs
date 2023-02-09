using UnityEngine;

/// <summary>
/// 하이어라키에 없어도 되는 싱글턴
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (_instance == null && Time.timeScale != 0f)
            {
                // 하이어라키에 없는 경우 생성
                var newObj = new GameObject();
                _instance = newObj.AddComponent<T>();
            }
            return _instance;
        }
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