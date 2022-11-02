using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int _score;
    private int _lvl;
    public int GlobalScore { get; private set; }

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction LevelUp; 
    

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void ResetLevel()
    {
        _score = 0;
        _lvl = 0;
        ScoreChanged?.Invoke(_score);
        _birdMover.ResetBird();
    }

    public void Die()
    {
        TrySaveScore(_score);
        GameOver?.Invoke();
    }

    public void IncreaseScore()
    {
        _score++;
        UpgradeLvl();       
        ScoreChanged?.Invoke(_score);
    }

    private void UpgradeLvl()
    {
        int maxLvl = 10;
        
        _lvl++;
        
        if (_lvl == maxLvl)
        {
            LevelUp?.Invoke();
            _lvl = 0;
        }
    }

    private void TrySaveScore(int score)
    {
        if (GlobalScore < score)
        {
            GlobalScore = score;
        }
        PlayerPrefs.SetInt("Score", GlobalScore);
    }
}