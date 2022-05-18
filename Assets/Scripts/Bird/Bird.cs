using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int _score;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void ResetLevel()
    {
        _score = 0;
        _birdMover.ResetBird();
    }

    public void Die()
    {
        Debug.Log("I'm die");
        Time.timeScale = 0;
    }
}