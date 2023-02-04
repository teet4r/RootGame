using UnityEngine;
using UnityEngine.EventSystems;

public class DefenseGameManager : MonoBehaviour
{
    public AllyController allyController = null;
    public EnemyController enemyController = null;
    public Transform allyHomeTr = null;
    public Transform enemyHomeTr = null;

    [SerializeField] Camera _camera = null;
    Transform _cameraTr = null;
    bool _isButtonClicked = false;
    int _clickedButtonIndex = -1;

    void Awake()
    {
        _cameraTr = _camera.transform;
    }
    void Update()
    {
        var curObj = EventSystem.current.currentSelectedGameObject;
        if (curObj == null) return;

        if (_isButtonClicked) // ��ư Ŭ���� �Ǿ��ٸ�
        {
            if (Input.touchCount == 1 && curObj.layer.Equals(11))
            {
                _isButtonClicked = false;
                var touch = Input.touches[0];
                var screenPosition = _camera.ScreenToWorldPoint(touch.position);
                MakeAllyFish(_clickedButtonIndex, new Vector3(screenPosition.x, screenPosition.y, 0f));
                _clickedButtonIndex = -1;
            }
        }

        if (!_isButtonClicked) // ��ư Ŭ���� �ȵǾ� �ִٸ�
        {
            switch (curObj.layer)
            {
                case 6: // 0�� ��ư
                    _isButtonClicked = true;
                    _clickedButtonIndex = 0;
                    break;
                case 7: // 1�� ��ư
                    _isButtonClicked = true;
                    _clickedButtonIndex = 1;
                    break;
                case 8: // 2�� ��ư
                    _isButtonClicked = true;
                    _clickedButtonIndex = 2;
                    break;
                case 9: // 3�� ��ư
                    _isButtonClicked = true;
                    _clickedButtonIndex = 3;
                    break;
                case 10: // 4�� ��ư
                    _isButtonClicked = true;
                    _clickedButtonIndex = 4;
                    break;
            }
        }
    }

    public void MakeAllyFish(int buttonIndex, Vector3 position)
    {
        var dataManager = DataManager.instance;
        var data = dataManager.allyDatas[(int)ButtonsManager.instance.redBeans[buttonIndex]];
        var remainCost = dataManager.costText.curCost - data.Cost;
        if (remainCost < 0)
            return;
        dataManager.costText.UpdateCost(remainCost);
        
        var clone = Instantiate(allyController, position, Quaternion.Euler(data.Rotation));
        clone.data = data;
        clone.CapsuleCollider.size = data.ColliderSize;
        clone.SpriteRenderer.sprite = data.Sprite;
        clone.SpriteRenderer.color = data.Color;
        clone.mainTarget = enemyHomeTr;
    }
    public void MakeEnemyFish(int buttonIndex, Vector3 position)
    {
        var dataManager = DataManager.instance;
        var data = dataManager.enemyDatas[(int)ButtonsManager.instance.redBeans[buttonIndex]];
        
        var clone = Instantiate(enemyController, position, Quaternion.Euler(data.Rotation));
        clone.data = data;
        clone.CapsuleCollider.size = data.ColliderSize;
        clone.SpriteRenderer.sprite = data.Sprite;
        clone.SpriteRenderer.color = data.Color;
        clone.mainTarget = allyHomeTr;
    }
}
