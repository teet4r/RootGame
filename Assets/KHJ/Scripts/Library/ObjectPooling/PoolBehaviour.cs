using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 풀 매니저에서 관리하기 용이하도록
/// 모든 GameObject prefab은 해당 스크립트를 가져야 함.
/// </summary>
public class PoolBehaviour : MonoBehaviour
{
    public Prefab Type
    {
        get { return _type; }
    }
    public float ReturnTime
    {
        get { return _returnTime; }
    }

    [SerializeField] Prefab _type;
    [Min(0f)][SerializeField] float _returnTime = Mathf.Infinity;

    WaitForSeconds _wfsReturnTime = null;
    Coroutine _returnCor = null;

    protected virtual void Awake()
    {
        SceneManager.sceneLoaded += OnChangeScene;

        _wfsReturnTime = new WaitForSeconds(_returnTime);
    }
    protected virtual void OnEnable()
    {
        StartTimer();
    }
    protected virtual void OnDisable()
    {
        StopTimer();
    }
    protected virtual void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnChangeScene;
    }

    void StartTimer()
    {
        if (_returnCor != null) return;

        _returnCor = StartCoroutine(_ReturnToPool());
    }
    void StopTimer()
    {
        if (_returnCor == null) return;

        StopCoroutine(_returnCor);
        _returnCor = null;
        PoolManager.Instance.Put(this);
    }
    /// <summary>
    /// 씬이 변경되면 모든 활성화된 프리팹을 풀에 반환
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="loadSceneMode"></param>
    void OnChangeScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        StopTimer();
    }

    IEnumerator _ReturnToPool()
    {
        yield return _wfsReturnTime;

        PoolManager.Instance.Put(this);
    }
}
