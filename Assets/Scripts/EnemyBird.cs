using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : Enemy
{
    [Header("Параметры птицы")]
    public Transform[] targetPositions;
    public float changeTarget = 0.1f;
    Transform birdTransform;
    int targetNumber = 0;
    bool straight = true;

    private void Start()
    {
        birdTransform = GetComponent<Transform>();
    }

    public override void Moove()
    {
        if (Vector2.Distance(targetPositions[targetNumber].position, birdTransform.position) < changeTarget)
        {
            if (straight)
            {
                if (targetNumber == targetPositions.Length - 1)
                {
                    targetNumber--;
                    straight = false;
                    Flip();
                }
                else targetNumber++;
            }
            else
            {
                if (targetNumber == 0)
                {
                    targetNumber++;
                    straight = true;
                    Flip();
                }
                else targetNumber--;
            }
        }
        birdTransform.position = Vector2.MoveTowards(birdTransform.position, targetPositions[targetNumber].position, speed);
    }
    public override void Flip()
    {
        isRight = !isRight;
        birdTransform.Rotate(0f, 180f, 0f);
    }
}
