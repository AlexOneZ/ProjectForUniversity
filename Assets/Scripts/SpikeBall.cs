using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    float angle;
    public int deviation;

    void FixedUpdate()
    {
        angle = Mathf.Sin(Time.time) * deviation;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
