using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float maxPosX = 240f;
    [SerializeField] private float moveSpeed = 400f;
    [SerializeField] private GameObject officeObject;

    void Update()
    { 
        if (Input.GetKey(KeyCode.A) && officeObject.transform.localPosition.x < maxPosX)
        {
            //Move officeObject left
            float pos = officeObject.transform.position.x + moveSpeed * Time.deltaTime;
            officeObject.transform.position = new Vector3(pos, officeObject.transform.position.y, officeObject.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.D) && officeObject.transform.localPosition.x > -maxPosX)
        {
            //Move officeObject right
            float pos = officeObject.transform.position.x - moveSpeed * Time.deltaTime;
            officeObject.transform.position = new Vector3(pos, officeObject.transform.position.y, officeObject.transform.position.z);
        }
    }
}
