using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
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
    public CircleCollider2D CircleCollider
    {
        get { return _circleCollider; }
    }
    public Rigidbody2D Rigidbody2D
    {
        get { return _rigidbody; }
    }
    public CharacterData Data
    {
        get { return _data; }
    }

    [SerializeField] Transform _transform = null;
    [SerializeField] SpriteRenderer _spriteRenderer = null;
    [SerializeField] CapsuleCollider2D _capsuleCollider = null;
    [SerializeField] CircleCollider2D _circleCollider = null;
    [SerializeField] Rigidbody2D _rigidbody = null;
    [SerializeField] CharacterData _data = null;

    void OnEnable()
    {
        Invoke("_Destroy", 10f);
    }
    void Update()
    {
        
    }

    void _Destroy()
    {
        Destroy(gameObject);
    }
}
