using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ISpawn
{
    void Update()
    {
        if (transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }

    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}
