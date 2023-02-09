using UnityEngine;
using UnityEngine.UI;

public class CardGameTimeBar : MonoBehaviour, ICustomUpdate
{
    public static CardGameTimeBar instance;

    [SerializeField] float maxTime;
    [SerializeField] float nowTime;
    [SerializeField] Image timeBar;
    [SerializeField] bool timeGo;
    public float MaxTime { get { return maxTime; } }
    public float NowTime { get { return nowTime; } }

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        RegisterCustomUpdate();
    }

    private void Start()
    {
        timeGo = true;
        FillTimeBar();
    }

    public void CustomUpdate()
    {
        if (timeGo)
        {
            if (nowTime <= 0f) CardManager.instance.GameOver();
            nowTime -= Time.deltaTime;
            timeBar.fillAmount = nowTime / maxTime;
        }
    }

    private void OnDisable()
    {
        DeregisterCustomUpdate();
    }

    public void FillTimeBar()
    {
        nowTime = maxTime;
    }

    public void StopTImeBar()
    {
        timeGo = false;
    }



    public void RegisterCustomUpdate()
    {
        CustomUpdateManager.Instance.RegisterCustomUpdate(this);
    }

    public void DeregisterCustomUpdate()
    {
        CustomUpdateManager.Instance.DeregisterCustomUpdate(this);
    }
}