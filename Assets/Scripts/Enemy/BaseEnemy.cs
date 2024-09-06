using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}
