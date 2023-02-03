using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData")]
public class CharacterData : ScriptableObject
{
    public Image Image
    {
        get { return _image; }
    }
    public int MaxHp
    {
        get { return _maxHp; }
    }
    public int Damage
    {
        get { return _damage; }
    }
    public float Range
    {
        get { return _range; }
    }
    public int Cost
    {
        get { return _cost; }
    }

    [SerializeField] Image _image;
    [Min(1)][SerializeField] int _maxHp;
    [Min(0)][SerializeField] int _damage;
    [Min(0f)][SerializeField] float _range;
    [Min(0)][SerializeField] int _cost;
}
