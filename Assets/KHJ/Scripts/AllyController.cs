using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class AllyController : PoolBehaviour, ICustomUpdate
{
    public Transform Transform
    {
        get { return _transform; }
    }
    public SpriteRenderer SpriteRenderer
    {
        get { return _spriteRenderer; }
    }
    public CharacterData data { get; set; } = null;
    public Transform MainTarget { get; set; } = null;
    
    [SerializeField] Transform _transform = null;
    [SerializeField] SpriteRenderer _spriteRenderer = null;

    float _fireRate = 1f;
    Transform _semiTarget = null;
    bool _enemyDetected = false;
    int _curHp;
    float _prevFireTime;

    protected override void OnEnable()
    {
        base.OnEnable();

        RegisterCustomUpdate();
    }
    void Start()
    {
        _curHp = data.MaxHp;
        _prevFireTime = Time.time;
    }
    public void CustomUpdate()
    {
        if (DefenseGameManager.instance.isGameOver) return;

        if (!_enemyDetected)
        {
            if (MainTarget != null && MainTarget.gameObject.activeSelf)
            {
                _LookAt(MainTarget.position);
                _transform.position = Vector3.MoveTowards(_transform.position, MainTarget.position, data.Speed * Time.deltaTime);
                if (Vector3.Distance(MainTarget.position, _transform.position) <= data.Range)
                    _MakeBullet();

                var detectedEnemy = Physics2D.OverlapCircle(_transform.position, data.Range, 1 << 13);
                if (detectedEnemy != null && detectedEnemy.gameObject.activeSelf)
                {
                    _enemyDetected = true;
                    _semiTarget = detectedEnemy.transform;
                }
            }
        }
        else
        {
            if (_semiTarget != null && _semiTarget.gameObject.activeSelf)
            {
                _LookAt(_semiTarget.position);
                if (Vector3.Distance(_semiTarget.position, _transform.position) <= data.Range) // 범위 안에 들어오면 공격
                    _MakeBullet();
                else
                    _transform.position = Vector3.MoveTowards(_transform.position, _semiTarget.position, data.Speed * Time.deltaTime);
            }
            else
                _enemyDetected = false;
        }
    }
    protected override void OnDisable()
    {
        base.OnDisable();

        DeregisterCustomUpdate();
    }

    public void GetDamage(int damage)
    {
        if (DefenseGameManager.instance.isGameOver) return;

        _curHp = Mathf.Max(_curHp - damage, 0);
        if (_curHp <= 0)
        {
            SoundManager.Instance.SfxAudio.Play(Sfx.BungkoDead);
            PoolManager.Instance.Put(this);
        }
    }

    void _MakeBullet()
    {
        if (Time.time - _prevFireTime < _fireRate)
            return;

        _prevFireTime = Time.time;
        var bullet = Instantiate(data.Bullet, _transform.position, _transform.rotation);
        var allyBullet = bullet.GetComponent<AllyBullet>();
        allyBullet.damage = data.Damage;
        SoundManager.Instance.SfxAudio.Play(Sfx.BungkoAttack);
    }
    void _LookAt(Vector2 targetPosition)
    {
        var angle = Mathf.Atan2(targetPosition.y - _transform.position.y, targetPosition.x - _transform.position.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }



    public void RegisterCustomUpdate()
    {
        CustomUpdateManager.Instance.RegisterCustomUpdate(this);
    }
    public void DeregisterCustomUpdate()
    {
        CustomUpdateManager.Instance.DeregisterCustomUpdate(this);
    }
}
