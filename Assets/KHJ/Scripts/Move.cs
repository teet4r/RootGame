using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    Transform _transform = null;
    Collider2D _bodyCollider = null;
    Rigidbody2D _rigidbody2D = null;

    void Awake()
    {
        _transform = GetComponent<Transform>();
        _bodyCollider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        _rigidbody2D.velocity = new Vector2(transform.position.x, _moveSpeed);
    }
    void OnDisable()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
}
