using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform[] targetPositions;
    public float speed, changeTarget = 0.1f;
    Transform sawTransform;
    int targetNumber = 0;
    bool straight = true;

    private void Start()
    {
        sawTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(targetPositions[targetNumber].position, sawTransform.position) < changeTarget)
        {
            if (straight)
            {
                if (targetNumber == targetPositions.Length - 1)
                {
                    targetNumber--;
                    straight = false;
                }
                else targetNumber++;
            }
            else
            {
                if (targetNumber == 0)
                {
                    targetNumber++;
                    straight = true;
                }
                else targetNumber--;
            }
        }
        sawTransform.position = Vector2.MoveTowards(sawTransform.position, targetPositions[targetNumber].position, speed);
    }
}
