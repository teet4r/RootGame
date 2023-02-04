using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBullet : MonoBehaviour
{
    public Transform tr = null;
    public CircleCollider2D circleCollider = null;
    public Rigidbody2D rb2D = null;
    public int damage;

    [SerializeField] float speed;
    [SerializeField] float _destroyTime = 7f;

    void Start()
    {
        rb2D.velocity = tr.up * speed;

        Invoke("_Destroy", _destroyTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            if (collision.gameObject.TryGetComponent(out AllyController allyController))
                allyController.GetDamage(damage);
            else if (collision.gameObject.TryGetComponent(out HomeController homeController))
                homeController.GetDamage(damage);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 12)
        {
            if (collision2D.gameObject.TryGetComponent(out AllyController allyController))
                allyController.GetDamage(damage);
            else if (collision2D.gameObject.TryGetComponent(out HomeController homeController))
                homeController.GetDamage(damage);
            Destroy(gameObject);
        }
    }

    void _Destroy()
    {
        Destroy(gameObject);
    }
}
