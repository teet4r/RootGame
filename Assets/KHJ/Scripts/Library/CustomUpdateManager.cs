using System.Collections.Generic;
using System.Diagnostics;

public class CustomUpdateManager : Singleton<CustomUpdateManager>
{
    class CustomUpdatePool<T>
    {
        const int _initialSize = 50;
        int _sizeThreshold = (int)(_initialSize * 0.1f);

        // for으로 실행할 Custom 오브젝트 배열
        public T[] customObjs = new T[_initialSize];

        // Custom 오브젝트에게 부여된 인덱스 저장
        Dictionary<T, int> _customObjIndexes = new Dictionary<T, int>();

        // 사용 가능한 번호표 풀
        // 사용할 번호표 발급 및 사용한 번호표 회수할 스택
        Stack<int> _indexPool = new Stack<int>();

        // Constructor
        public CustomUpdatePool()
        {
            // initialize
            for (int i = 0; i < _initialSize; i++)
                _indexPool.Push(i);
        }
        public void Register(T obj)
        {
            if (_indexPool.Count <= _sizeThreshold)
                _ResizeCustomArray();

            // 이미 등록돼 있다면 종료
            if (_customObjIndexes.TryGetValue(obj, out int index))
                return;
            // 없다면 새로 등록
            else
            {
                index = _indexPool.Pop();
                _customObjIndexes.Add(obj, index);
                customObjs[index] = obj;
            }
        }
        public void Deregister(T obj)
        {
            // 풀에 존재한다면 삭제
            if (_customObjIndexes.TryGetValue(obj, out int index))
            {
                customObjs[index] = default;
                _indexPool.Push(index);
                _customObjIndexes.Remove(obj);
            }
        }

        void _ResizeCustomArray()
        {
            int newSize = customObjs.Length * 2;
            _sizeThreshold = (int)(newSize * 0.1f);
            T[] _newCustomObjs = new T[newSize];
            for (int i = 0; i < customObjs.Length; i++)
                _newCustomObjs[i] = customObjs[i];
            for (int i = customObjs.Length; i < newSize; i++)
                _indexPool.Push(i);

            customObjs = _newCustomObjs;
        }
    }

    CustomUpdatePool<ICustomUpdate> _updatePool = new CustomUpdatePool<ICustomUpdate>();
    CustomUpdatePool<ICustomFixedUpdate> _fixedUpdatePool = new CustomUpdatePool<ICustomFixedUpdate>();
    CustomUpdatePool<ICustomLateUpdate> _lateUpdatePool = new CustomUpdatePool<ICustomLateUpdate>();
    bool _isCreated = false;

    protected override void Awake()
    {
        base.Awake();

        Create();
    }

    void Update()
    {
        for (int i = 0; i < _updatePool.customObjs.Length; i++)
            if (_updatePool.customObjs[i] != null)
                _updatePool.customObjs[i].CustomUpdate();
    }
    void FixedUpdate()
    {
        for (int i = 0; i < _fixedUpdatePool.customObjs.Length; i++)
            if (_fixedUpdatePool.customObjs[i] != null)
                _fixedUpdatePool.customObjs[i].CustomFixedUpdate();
    }
    void LateUpdate()
    {
        for (int i = 0; i < _lateUpdatePool.customObjs.Length; i++)
            if (_lateUpdatePool.customObjs[i] != null)
                _lateUpdatePool.customObjs[i].CustomLateUpdate();
    }

    public void Create()
    {
        if (_isCreated) return;
        _isCreated = true;
    }
    public void RegisterCustomUpdate(ICustomUpdate obj)
    {
        _updatePool.Register(obj);
    }
    public void RegisterCustomFixedUpdate(ICustomFixedUpdate obj)
    {
        _fixedUpdatePool.Register(obj);
    }
    public void RegisterCustomLateUpdate(ICustomLateUpdate obj)
    {
        _lateUpdatePool.Register(obj);
    }
    public void DeregisterCustomUpdate(ICustomUpdate obj)
    {
        _updatePool.Deregister(obj);
    }
    public void DeregisterCustomFixedUpdate(ICustomFixedUpdate obj)
    {
        _fixedUpdatePool.Deregister(obj);
    }
    public void DeregisterCustomLateUpdate(ICustomLateUpdate obj)
    {
        _lateUpdatePool.Deregister(obj);
    }
}
