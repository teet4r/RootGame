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
    public int screenHalfHeight;
    public int screenHalfWidth;

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
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            2, 4, new EnemyFish[] {
                EnemyFish.MiniFish_CC,
            }),
        new Wave(
            3, 7, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            4, 10, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            5, 13, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            6, 16, new EnemyFish[] {
                EnemyFish.MiniFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            7, 19, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            8, 22, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            9, 25, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            10, 28, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            11, 31, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            12, 34, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            13, 37, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            14, 40, new EnemyFish[] {
                EnemyFish.GoldFish,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            15, 43, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            16, 46, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            17, 49, new EnemyFish[] {
                EnemyFish.AgariFish_CC,
            }),
        new Wave(
            18, 52, new EnemyFish[] {
                EnemyFish.MiniFish_CC,
                EnemyFish.MiniFish_CC,
            }),
        new Wave(
            19, 55, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            20, 58, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            21, 61, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
                EnemyFish.GoldFish,
            }),
        new Wave(
            22, 64, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            23, 67, new EnemyFish[] {
                EnemyFish.AgariFish_CC,
                EnemyFish.AgariFish_CC,
            }),
        new Wave(
            24, 70, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            25, 73, new EnemyFish[] {
                EnemyFish.AgariFish_CC,
                EnemyFish.AgariFish_CC,
                EnemyFish.AgariFish_CC,
            }),
        new Wave(
            26, 76, new EnemyFish[] {
                // Empty
            }),
        new Wave(
            27, 79, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.MiniFish_CC,
                EnemyFish.MiniFish_CC,
            }),
        new Wave(
            28, 82, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            29, 85, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            30, 88, new EnemyFish[] {
                EnemyFish.AgariFish_CC,
                EnemyFish.AgariFish_CC,
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            31, 91, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            32, 94, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
                EnemyFish.GoldFish,
                EnemyFish.GoldFish,
            }),
        new Wave(
            33, 97, new EnemyFish[] {
                EnemyFish.GoldFish,
                EnemyFish.GoldFish,
                EnemyFish.GoldFish,
            }),
        new Wave(
            34, 100, new EnemyFish[] {
                // Empty
            }),
        new Wave(
            35, 103, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            36, 106, new EnemyFish[] {
                EnemyFish.TaiyakiFish_CC,
                EnemyFish.TaiyakiFish_CC,
            }),
        new Wave(
            37, 109, new EnemyFish[] {
                EnemyFish.AgariFish_CC,
                EnemyFish.AgariFish_CC,
                EnemyFish.AgariFish_CC,
            }),
        new Wave(
            38, 112, new EnemyFish[] {
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.BurntFish_CC,
            }),
        new Wave(
            39, 115, new EnemyFish[] {
                EnemyFish.GoldFish,
                EnemyFish.GoldFish,
                EnemyFish.GoldFish,
            }),
        new Wave(
            40, 118, new EnemyFish[] {
                // Empty
            }),
        new Wave(
            41, 121, new EnemyFish[] {
                EnemyFish.MiniFish_CC,
                EnemyFish.BurntFish_CC,
                EnemyFish.TaiyakiFish_CC,
                EnemyFish.GoldFish,
                EnemyFish.AgariFish_CC,
            }),
    };

    [SerializeField] GameObject _clearGroup;
    [SerializeField] GameObject _gameOverGroup;

    void Awake()
    {
        if (instance == null)
            instance = this;

        _cameraTr = _camera.transform;
        cameraHalfHeight = _camera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * _camera.aspect;
        screenHalfHeight = Screen.height / 2;
        screenHalfWidth = Screen.width / 2;
    }
    void Start()
    {
        allyHome.tr.position = new Vector2(0f, -cameraHalfHeight + cameraHalfHeight * 2f * 0.2f + 0.15f);
        enemyHome.tr.position = new Vector2(0f, cameraHalfHeight - (144 * (cameraHalfHeight / screenHalfHeight)));

        _totalTime = 0f;

        SoundManager.Instance.BgmAudio.Play(Bgm.DefenseGame);
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
        SoundManager.Instance.SfxAudio.Play(Sfx.BungkoSummon);
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
        SoundManager.Instance.SfxAudio.Play(Sfx.BungkoSummon);
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
        SoundManager.Instance.SfxAudio.Play(Sfx.BungkoSummon);
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
                    SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
                    break;
                case 7: // 1번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 1;
                    SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
                    break;
                case 8: // 2번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 2;
                    SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
                    break;
                case 9: // 3번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 3;
                    SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
                    break;
                case 10: // 4번 버튼
                    _isButtonClicked = true;
                    _clickedButtonIndex = 4;
                    SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
                    break;
            }
        }
    }
    void _WaveRunner()
    {
        if (isGameOver) return;
        if (_waveIndex >= _waves.Length) return;

        _totalTime += Time.deltaTime;
        if (_totalTime >= _waves[_waveIndex].waitTime)
        {
            for (int i = 0; i < _waves[_waveIndex].enemies.Length; i++)
            {
                float randomX = Random.Range(-cameraHalfWidth, cameraHalfWidth);
                float randomY = Random.Range(cameraHalfHeight * 0.8f, cameraHalfHeight);
                MakeEnemyFish((int)_waves[_waveIndex].enemies[i], new Vector3(randomX, randomY, 0f));
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
            _gameOverGroup.SetActive(true);
            ScoreManager.instance.SetGame1Score(_totalTime);
        }
        else if (allyHome.curHp > 0 && enemyHome.curHp <= 0)
        {
            isWin = true;
            isGameOver = true;
            _clearGroup.SetActive(true);
            ScoreManager.instance.SetGame1Score(_totalTime);
        }
        else if (allyHome.curHp <= 0 && enemyHome.curHp > 0)
        {
            isWin = false;
            isGameOver = true;
            _gameOverGroup.SetActive(true);
            ScoreManager.instance.SetGame1Score(_totalTime);
        }
    }
}
