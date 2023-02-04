using UnityEngine;

public class HomeController : MonoBehaviour
{
    public Transform tr = null;
    public int maxHp = 1000;

    int _curHp;

    void Start()
    {
        _curHp = maxHp;
    }

    public void GetDamage(int damage)
    {
        _curHp = Mathf.Max(_curHp - damage, 0);
        if (_curHp <= 0)
            Destroy(gameObject);
    }
}
