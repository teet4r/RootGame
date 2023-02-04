using UnityEngine;

[RequireComponent(typeof(Collider2D))]
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
    public Collider2D Collider2D
    {
        get { return _collider; }
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
    [SerializeField] Collider2D _collider = null;
    [SerializeField] Rigidbody2D _rigidbody = null;
    [SerializeField] CharacterData _data = null;

    void OnEnable()
    {
        Invoke("_Destroy", 10f);
    }

    void _Destroy()
    {
        Destroy(gameObject);
    }
}
