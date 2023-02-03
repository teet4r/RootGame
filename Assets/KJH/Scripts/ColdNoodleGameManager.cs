using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdNoodleGameManager : SingletonMonoBehaviour<ColdNoodleGameManager>
{
    [SerializeField]
    public Queue<GameObject> queue;
    private GameObject curChicken;
    public GameObject friedPrefab;
    public GameObject saucePrefab;
    public int score;
    public int scoremultiflyvalue = 1;
    public int combo;

    public float timeCurrent;
    public float timemultiflyvalue = 1;
    public float timeMax = 60;
    private float timePlus;
    
    // Start is called before the first frame update
    void Start()
    {
        queue = new Queue<GameObject>();
        if (queue.Count == 0)
        {
            MakeRandomNoodle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeCheck() < 0)
        {
            GameOver();
        }

        
    }

    void MakeRandomNoodle()
    {
        // 큐 50개 만듬 
        for (int i = 0; i < 50; i++)
        {
            if (Random.Range(0,2) == 0)
            {
                queue.Enqueue(friedPrefab);
            }
            else
            {
                queue.Enqueue(saucePrefab);
            }
        }
    }

    public GameObject DequeueChicken()
    {
        curChicken = queue.Dequeue();
        queue.Enqueue(curChicken);
        return curChicken;
    }
    public void PlusCombo()
    {
        combo += 1;
        score += 100 * scoremultiflyvalue;

        if (combo % 10 == 0)
        {
            scoremultiflyvalue += 1;
            timemultiflyvalue += 0.1f;
        }
        // combo 증가, 점수 증가, 남은 시간 1.5초 증가, 
        // 10 combo마다 1초당 감소 시간을 늘림 
    }

    private float TimeCheck()
    {
        timeCurrent = timeMax - Time.time * timemultiflyvalue + timePlus;
        if (timeCurrent >= timeMax) timeCurrent = timeMax;
        return timeCurrent;
        // 제한시간 체크
    }
    private void GameOver()
    {
        // 게임 종료, UI 표시(다시하기, Main 이동) 
    }
    
}
