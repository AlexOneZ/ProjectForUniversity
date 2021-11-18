using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDeleter : MonoBehaviour
{
    public float delay;

    void Start()
    {
        Invoke("DeleteEffect", delay);
    }

    void DeleteEffect()
    {
        Destroy(this.gameObject);
    }
}
