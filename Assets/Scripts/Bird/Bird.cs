using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;
    

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void ResetLevel()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _birdMover.ResetBird();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}