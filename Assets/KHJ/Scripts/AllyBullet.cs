using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class AllyBullet : MonoBehaviour
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
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 13)
        {
            if (collider.gameObject.TryGetComponent(out EnemyController enemyController))
                enemyController.GetDamage(damage);
            else if (collider.gameObject.TryGetComponent(out HomeController homeController))
                homeController.GetDamage(damage);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            if (collision.gameObject.TryGetComponent(out EnemyController enemyController))
                enemyController.GetDamage(damage);
            else if (collision.gameObject.TryGetComponent(out HomeController homeController))
                homeController.GetDamage(damage);
            Destroy(gameObject);
        }
    }

    void _Destroy()
    {
        Destroy(gameObject);
    }
}
