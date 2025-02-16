using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreensMovement : MonoBehaviour
{
    [SerializeField] private float maxPosX = 240f;
    [SerializeField] private float moveSpeed = 400f;
    private int direction = -1;

    void Update()
    {
        transform.localPosition += Vector3.right * moveSpeed * direction * Time.deltaTime;

        //Change direction
        if (transform.localPosition.x <= -maxPosX)
        {
            //Move left
            direction = 1;
        }
        else if (transform.localPosition.x >= maxPosX)
        {
            //Move right
            direction = -1;
        }
    }
}
