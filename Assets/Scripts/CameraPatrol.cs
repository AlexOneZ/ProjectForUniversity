using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPatrol : MonoBehaviour
{
    [SerializeField]
    Transform cameraTransform, playerTransform;
    public float smoothing;
    public Vector3 offset = new Vector3(0f, 2f, -10f);

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        playerTransform = GameManager.GM.activePlayer.transform;
    }

    void FixedUpdate()
    {
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, playerTransform.position + offset, Time.deltaTime * smoothing);
    }
}
