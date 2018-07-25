using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraA : MonoBehaviour
{
    public Camera camera;
    //public GameObject player;

    public float speed = 1f;
    //float cameraSize = 5f;

    public float MaxSize = 10f;
    public float MinSize = 5f;   

    void Update()
    {

        camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
        if (camera.orthographicSize >= 7)
        {
            camera.orthographicSize = 7f;
        }
        if (camera.orthographicSize <= 3)
        {
            camera.orthographicSize = 3f;
        }

    }
}
