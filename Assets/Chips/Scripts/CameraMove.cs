using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    public float speed = 100f;
    public float normalSpeed;

    public Transform CameraController;
    public Transform player_body;

    float xRotation = 0f;
    
    public static CameraMoveController instance;
    void Start()
    {
        instance = this;
        normalSpeed = speed;
        Cursor.lockState = CursorLockMode.Locked;
    }



    void Update()
    {
        float x = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        CameraController.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player_body.Rotate(player_body.up * x);
    }

}


