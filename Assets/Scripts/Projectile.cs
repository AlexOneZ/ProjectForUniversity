using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, destroyTime = 5f;

    void Start()
    {
        Invoke("Delete", destroyTime);
    }

    private void FixedUpdate()
    {
        transform.Translate(speed, 0f, 0f);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
