using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wave
{
    public int wave;
    public int waitTime;
    public EnemyFish[] enemies;

    public Wave(int wave, int waitTime, EnemyFish[] enemies)
    {
        this.wave = wave;
        this.waitTime = waitTime;
        this.enemies = enemies;
    }
}

public class DefenseGameManager : MonoBehaviour
{
    public static DefenseGameManager instance = null;
    public float cameraHalfHeight;
    public float cameraHalfWidth;

    public AllyController allyController = null;
    public EnemyController enemyController = null;
    public HomeController allyHome = null;
    public HomeController enemyHome = null;
    public bool isGameOver = false;
    public bool isWin = false;

    [SerializeField] Camera _camera = null;
    Transform _cameraTr = null;
    bool _isButtonClicked = false;
    int _clickedButtonIndex = -1;

    float _totalTime;
    int _waveIndex = 0;
    Wave[] _waves =
    {
        new Wave(
            1, 1, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC
            }),
        new Wave(
            2, 4, new EnemyFish[] {
                EnemyFish.MiniFish_CC
            }),
        new Wave(
            3, 7, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC
            }),
        new Wave(
            4, 10, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC
            }),
        new Wave(
            5, 13, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC
            }),
        new Wave(
            6, 16, new EnemyFish[] {
                EnemyFish.MiniFish_CC
            }),
        new Wave(
            7, 19, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC
            }),
        new Wave(
            8, 22, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC
            }),
        new Wave(
            9, 25, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC
            }),
        new Wave(
            10, 28, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC
            }),
    };

    void Awake()
    {
        if (instance == null)
            instance = this;

        _cameraTr = _camera.transform;
        cameraHalfHeight = _camera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * _camera.aspect;
    }
    void Start()
    {
        _totalTime = 0f;

        StartCoroutine(_DeployEnemy());
    }
    void Update()
    {
        if (isGameOver) return;

        _JudgeWin();
        _ButtonEventListener();
        _WaveRunner();
    }

    public void MakeAllyFish(int buttonIndex, Vector3 position)
    {
        var dataManager = DataManager.instance;
        var data = dataManager.allyDatas[(int)ButtonsManager.instance.redBeans[buttonIndex]];
        var remainCost = dataManager.costText.curCost - data.Cost;
        if (remainCost < 0)
            return;
        dataManager.costText.UpdateCost(remainCost);

        if (enemyHome == null) return;
        var clone = Instantiate(allyController, position, Quaternion.Euler(data.Rotation));
        clone.data = data;
        clone.CapsuleCollider.size = data.ColliderSize;
        clone.SpriteRenderer.sprite = data.Sprite;
        clone.SpriteRenderer.color = data.Color;
        clone.mainTarget = enemyHome.transform;
    }
    public void MakeEnemyFish(int index, Vector3 position)
    {
        var dataManager = DataManager.instance;
        var data = dataManager.enemyDatas[index];

        if (allyHome == null) return;
        var clone = Instantiate(enemyController, position, Quaternion.Euler(data.Rotation));
        clone.data = data;
        clone.CapsuleCollider.size = data.ColliderSize;
        clone.SpriteRenderer.sprite = data.Sprite;
        clone.SpriteRenderer.color = data.Color;
        clone.mainTarget = allyHome.transform;
    }
    public void MakeEnemyFish(Vector3 position)
    {
        var dataManager = DataManager.instance;
        var data = dataManager.enemyDatas[Random.Range(0, dataManager.enemyDatas.Length)];

        if (allyHome == null) return;
        var clone = Instantiate(enemyController, position, Quaternion.Euler(data.Rotation));
        clone.data = data;
        clone.CapsuleCollider.size = data.ColliderSize;
        clone.SpriteRenderer.sprite = data.Sprite;
        clone.SpriteRenderer.color = data.Color;
        clone.mainTarget = allyHome.transform;
    }

    IEnumerator _DeployEnemy()
    {
        WaitForSeconds wfs = new WaitForSeconds(2f);
        Vector2 spawnPoint = new Vector2(0f, 3.9f);

        while (!isGameOver)
        {
            yield return wfs;
            MakeEnemyFish(spawnPoint);
        }
    }
    void _ButtonEventListener()
    {
        var curObj = EventSystem.current.currentSelectedGameObject;
        if (curObj == null) return;

        if (_isButtonClicked) // 버튼 클릭이 되었다면
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

        if (!_isButtonClicked) // 버튼 클릭이 안되어 있다면
        {
            switch (curObj.layer)
            {
                case 6: // 0번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 0;
                    break;
                case 7: // 1번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 1;
                    break;
                case 8: // 2번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 2;
                    break;
                case 9: // 3번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 3;
                    break;
                case 10: // 4번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 4;
                    break;
            }
        }
    }
    void _WaveRunner()
    {
        if (_waveIndex >= _waves.Length) return;

        _totalTime += Time.deltaTime;
        if (_totalTime >= _waves[_waveIndex].waitTime)
        {
            for (int i = 0; i < _waves[_waveIndex].enemies.Length; i++)
            {
                float randomX = Random.Range(-cameraHalfWidth, cameraHalfWidth);
                float randomY = Random.Range(cameraHalfHeight * 0.8f, cameraHalfHeight);
                MakeEnemyFish(new Vector3(randomX, randomY, 0f));
            }
            _waveIndex++;
        }
    }
    void _JudgeWin()
    {
        if (allyHome.curHp <= 0 && enemyHome.curHp <= 0)
        {
            isWin = false;
            isGameOver = true;
        }
        else if (allyHome.curHp > 0 && enemyHome.curHp <= 0)
        {
            isWin = true;
            isGameOver = true;
        }
        else if (allyHome.curHp <= 0 && enemyHome.curHp > 0)
        {
            isWin = false;
            isGameOver = true;
        }
    }

}
