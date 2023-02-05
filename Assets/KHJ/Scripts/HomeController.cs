using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public Transform tr = null;
    public int maxHp = 1000;
    public int curHp;

    [SerializeField] Text _hpText = null;

    void Start()
    {
        curHp = maxHp;

        _UpdateHpText();
    }

    public void GetDamage(int damage)
    {
        curHp = Mathf.Max(curHp - damage, 0);
        _UpdateHpText();
        if (curHp <= 0)
            Destroy(gameObject);
    }
    
    void _UpdateHpText()
    {
        var ratio = (float)curHp / maxHp;
        _hpText.color = new Color(1f - ratio, ratio, 0f);
        _hpText.text = $"{curHp}";
    }
}
