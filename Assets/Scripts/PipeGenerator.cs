using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private Bird _bird;

    private float _elapsedTime = 0;

    private void OnEnable()
    {
        _bird.LevelUp += UpperSpeed;
    }

    private void OnDisable()
    {
        _bird.LevelUp -= UpperSpeed;
    }

    private void UpperSpeed()
    {
        _secondsBetweenSpawn -= 0.25f;
    }

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;
                
                DisableObjectAroadScreen();
            }
        }
    }
}