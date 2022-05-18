using System;
using UnityEngine;


public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _offSetX;

    private void Update()
    {
        transform.position =
            new Vector3(_bird.transform.position.x - _offSetX, transform.position.y, transform.position.z);
    }
}