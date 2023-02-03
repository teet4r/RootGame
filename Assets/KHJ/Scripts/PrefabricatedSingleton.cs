using UnityEngine;

public class PrefabricatedSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get { return _instance; }
    }
    static T _instance = null;

    protected virtual void Awake()
    {
        // ���̾��Ű�� �̹� ������� ��� ����
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