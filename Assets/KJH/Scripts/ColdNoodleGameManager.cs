using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColdNoodleGameManager : SingletonMonoBehaviour<ColdNoodleGameManager>
{
    public Queue<GameObject> queue;
    public Transform[] moveTransform; // 0:left, 1:right, 2,3,4,5,6,7 
    public Sprite[] heart;
    public Transform[] p;
    public GameObject curChicken;
    public GameObject friedPrefab;
    public GameObject saucePrefab;
    public int score;
    public int scoremultiflyvalue = 1;
    public int combo;

    public float timeCurrent=60f;
    public float timemultiflyvalue = 1;
    public float timeMax = 60;
    private float timePlus;

    float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        timeCurrent = timeMax;
        curChicken = null;
        if (queue != null)
        {
            for (int i = 0; i < queue.Count(); i++)
            {
                Destroy(queue.Dequeue());
            }
            queue.Clear();
        }
        queue = new Queue<GameObject>();
        if (queue.Count == 0)
        {
            MakeRandomNoodle();
        }
    }

    private void Update()
    {
        if (timeCurrent <= 0f) GameOver();
        timeCurrent -= Time.deltaTime * timemultiflyvalue * (Time.time - startTime);
    }

    public void MakeRandomNoodle()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Random.Range(0,2) == 0)
            {
                queue.Enqueue(Instantiate(friedPrefab, moveTransform[i + 2].position,Quaternion.identity));
            }
            else
            {
                queue.Enqueue(Instantiate(saucePrefab,moveTransform[i + 2].position,Quaternion.identity));
            }
        }
        
    }
    public void EnqueueRandomChicken()
    {
        // 6번째자리에 치킨추가
        if (Random.Range(0,2) == 0)
        {
            queue.Enqueue(Instantiate(friedPrefab,moveTransform[7].position,Quaternion.identity));
        }
        else
        {
            queue.Enqueue(Instantiate(saucePrefab,moveTransform[7].position,Quaternion.identity));
        }
    }
    public void DestrotyChicken()
    {
        for (int i = 0; i < queue.Count(); i++)
        {
            Destroy(queue.Dequeue());
        }
    }
    public GameObject DequeueChicken()
    {
        return queue.Dequeue();
    }
    public void PlusCombo()
    {
        combo += 1;
        if (combo % 20 == 0)
        {
            Instantiate(heart[Random.Range(0, 5)], p[Random.Range(0, 2)]);
            ColdNoodleUIManager.Instance.ShakeCombo2();
        }else ColdNoodleUIManager.Instance.ShakeCombo();
        score += 100 * scoremultiflyvalue;
        if (timePlus < 0f) timePlus = 0f;
        else timePlus += 1;
        if (combo % 10 == 0)
        {
            scoremultiflyvalue += 1;
            timemultiflyvalue += 0.3f;
        }
        // combo 증가, 점수 증가, 남은 시간 1.5초 증가, 
        // 10 combo마다 1초당 감소 시간을 늘림 
    }
    public void FailCombo()
    {
        Debug.Log("FailCombo");
        combo = 0;
        timePlus -= 20;
        ColdNoodleUIManager.Instance.resetComboSize();
    }

    public float TimeCheck()
    {
        timeCurrent += timePlus;
        if (timeCurrent >= timeMax) timeCurrent = timeMax;
        if (timeCurrent <= 0) GameOver();
        return timeCurrent;
        // 제한시간 체크
    }
    private void GameOver()
    {
        // 최종 점수 저장

        ScoreManager.instance.SetGame2Score(score);
        Debug.Log("GameOver");
        ColdNoodleUIManager.Instance.SetActiveGameOverUI();
        ColdNoodleUIManager.Instance.MoY();
        for (int i = 0; i < moveTransform.Length; i++)
        {
            moveTransform[i].gameObject.SetActive(false);    
        }
        Time.timeScale = 0;
        // 게임 종료, UI 표시(다시하기, Main 이동) 
    }
    
}
