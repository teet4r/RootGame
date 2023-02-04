using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData")]
public class CharacterData : ScriptableObject
{
    public Sprite Sprite
    {
        get { return _sprite; }
    }
    public Vector3 Rotation
    {
        get { return _rotation; }
    }
    public FishType FishType
    {
        get { return _fishType; }
    }
    public Color Color
    {
        get { return _color; }
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

    [SerializeField] Sprite _sprite;
    [SerializeField] Vector3 _rotation;
    [SerializeField] FishType _fishType;
    [SerializeField] Color _color;
    [Min(1)][SerializeField] int _maxHp;
    [Min(0)][SerializeField] int _damage;
    [Min(0f)][SerializeField] float _range;
    [Min(0)][SerializeField] int _cost;
}
