using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameObject를 저장하는 풀
/// Prefab 형태는 모두 여기서 관리
/// </summary>
public class PoolManager : PrefabricatedSingleton<PoolManager>
{
    [SerializeField] PoolBehaviour[] _prefabs = null;
    Stack<PoolBehaviour>[] _pools = null;
    Transform _transform = null;
    bool _isCreated = false;

    protected override void Awake()
    {
        base.Awake();

        Create();
    }

    public void Create()
    {
        if (_isCreated) return;
        _isCreated = true;

        _transform = GetComponent<Transform>();
        _pools = new Stack<PoolBehaviour>[_prefabs.Length];

        for (int i = 0; i < _prefabs.Length; i++)
        {
            // 복제된 오브젝트를 사용
            var originGameObject = _prefabs[i].gameObject;

            originGameObject.SetActive(false);
            _prefabs[i] = Instantiate(_prefabs[i], _transform);
            originGameObject.SetActive(true);

            _pools[i] = new Stack<PoolBehaviour>();
        }
    }
    public PoolBehaviour Get(Prefab type)
    {
        if (_pools[(int)type].Count == 0)
            return Instantiate(_prefabs[(int)type], _transform);
        return _pools[(int)type].Pop();
    }
    public void Put(PoolBehaviour prefab)
    {
        if (prefab.gameObject == null)
            return;

        prefab.gameObject.SetActive(false);
        _pools[(int)prefab.Type].Push(prefab);
    }
    public void Put(GameObject obj)
    {
        if (obj == null)
            return;

        if (obj.TryGetComponent(out PoolBehaviour poolBehaviour))
        {
            obj.SetActive(false);
            _pools[(int)poolBehaviour.Type].Push(poolBehaviour);
        }
        else
            Destroy(obj);
    }
}

public enum Prefab
{
    Monster, Skeleton, Zombie,
    Bullet, BulletTracer, Spark, Blood,
}