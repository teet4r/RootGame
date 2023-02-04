using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class AllyBullet : MonoBehaviour
{
    public Transform tr = null;
    public CircleCollider2D circleCollider = null;
    public Rigidbody2D rb2D = null;
    public int damage;
    public float speed;

    void Start()
    {
        rb2D.velocity = tr.forward * speed;
    }
    void OnCollisionEnter(Collision collision)
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
}
