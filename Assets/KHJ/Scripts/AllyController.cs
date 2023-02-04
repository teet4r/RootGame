using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class AllyController : MonoBehaviour
{
    public Transform Transform
    {
        get { return _transform; }
    }
    public SpriteRenderer SpriteRenderer
    {
        get { return _spriteRenderer; }
    }
    public CapsuleCollider2D CapsuleCollider
    {
        get { return _capsuleCollider; }
    }
    public Rigidbody2D Rigidbody2D
    {
        get { return _rigidbody; }
    }
    public CharacterData data = null;
    public Transform mainTarget = null;
    
    [SerializeField] Transform _transform = null;
    [SerializeField] SpriteRenderer _spriteRenderer = null;
    [SerializeField] CapsuleCollider2D _capsuleCollider = null;
    [SerializeField] Rigidbody2D _rigidbody = null;

    Transform _semiTarget = null;
    bool _enemyDetected = false;
    int _curHp;

    void OnEnable()
    {
        Invoke("_Destroy", 30f);
    }
    void Start()
    {
        _curHp = data.MaxHp;
    }
    void Update()
    {
        if (!_enemyDetected)
        {
            if (mainTarget != null)
            {
                _transform.LookAt(new Vector3(mainTarget.position.x, mainTarget.position.y, 0f));
                _rigidbody.MovePosition(mainTarget.position * Time.deltaTime);
                if (Vector3.Distance(mainTarget.position, _transform.position) <= data.Range)
                    _MakeBullet();

                var detectedEnemy = Physics2D.OverlapCircle(_transform.position, data.Range, 1 << 13);
                if (detectedEnemy != null)
                {
                    _enemyDetected = true;
                    _semiTarget = detectedEnemy.transform;
                }
            }
        }
        else
        {
            if (_semiTarget != null)
            {
                _transform.LookAt(_semiTarget);
                if (Vector3.Distance(_semiTarget.position, _transform.position) <= data.Range) // 범위 안에 들어오면 공격
                    _MakeBullet();
                else
                    _rigidbody.MovePosition(_semiTarget.position * Time.deltaTime);
            }
            else
                _enemyDetected = false;
        }
    }

    public void GetDamage(int damage)
    {
        _curHp = Mathf.Max(_curHp - damage, 0);
        if (_curHp <= 0)
            Destroy(gameObject);
    }

    void _MakeBullet()
    {
        var bullet = Instantiate(data.Bullet);
        bullet.transform.position = _transform.position;
        bullet.transform.eulerAngles = _transform.eulerAngles;
        var allyBullet = bullet.GetComponent<AllyBullet>();
        allyBullet.damage = data.Damage;
        allyBullet.speed = 3f;
    }
    void _Destroy()
    {
        Destroy(gameObject);
    }
}
