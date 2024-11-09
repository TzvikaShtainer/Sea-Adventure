using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ISpawn
{
    // Speed of the "3D" spin effect
    [SerializeField] private float spinSpeed = 2f;
    // Minimum scale to simulate the coin edge during rotation
    [SerializeField] private float minScale = 0.2f;
    // Maximum scale to allow control over the largest size during rotation
    [SerializeField] private float maxScale = 1.0f;

    private bool shrinking = true;

    void Update()
    {
        // Adjust the scale along the X-axis to simulate 3D flipping
        Vector3 scale = transform.localScale;

        // Change scale between minScale and maxScale
        if (shrinking)
        {
            scale.x -= spinSpeed * Time.deltaTime;
            if (scale.x <= minScale)
            {
                scale.x = minScale;
                shrinking = false;
            }
        }
        else
        {
            scale.x += spinSpeed * Time.deltaTime;
            if (scale.x >= maxScale)
            {
                scale.x = maxScale;
                shrinking = true;
            }
        }

        transform.localScale = scale;
    }
    
    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}
