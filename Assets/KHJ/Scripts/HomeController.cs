using UnityEngine;

public class HomeController : MonoBehaviour
{
    public Transform tr = null;
    public int maxHp = 1000;
    public int curHp;

    void Start()
    {
        curHp = maxHp;
    }

    public void GetDamage(int damage)
    {
        curHp = Mathf.Max(curHp - damage, 0);
        if (curHp <= 0)
            Destroy(gameObject);
    }
}
