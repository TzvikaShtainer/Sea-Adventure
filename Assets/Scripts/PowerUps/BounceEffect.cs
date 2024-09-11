using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    [SerializeField] private float bounceHeight = 0.5f; 
    [SerializeField] private float bounceSpeed = 2f;   
    private Vector3 startPosition;                     

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        
        transform.position = new Vector2(transform.position.x, newY);
    }
}
