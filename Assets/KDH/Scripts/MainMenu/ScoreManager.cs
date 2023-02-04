using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    float game1ScoreMax = -1;
    float game2ScoreMax = -1;
    float game3ScoreMax = -1;
    public float Game1ScoreMax { get { return game1ScoreMax; } }
    public float Game2ScoreMax { get { return game2ScoreMax; } }
    public float Game3ScoreMax { get { return game3ScoreMax; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetGame1Score(float _score)
    {
        if (_score > game1ScoreMax)
        {
            game1ScoreMax = _score;
        }
    }

    public void SetGame2Score(float _score)
    {
        if (_score > game2ScoreMax)
        {
            game2ScoreMax = _score;
        }
    }

    public void SetGame3Score(float _score)
    {
        if (_score > game3ScoreMax)
        {
            game3ScoreMax = _score;
        }
    }
}