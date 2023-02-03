using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            InitInstance();
            return _instance;
        }
    }

    private static void InitInstance()
    {
        if(_instance != null)
        {
            return;
        }
        else
        {
            _instance = GameObject.FindObjectOfType<T>();
            
            if(_instance == null)
            {
                GameObject obj = new GameObject(typeof(T).Name);
                _instance = obj.AddComponent<T>();    
            }
        }
    }
}
