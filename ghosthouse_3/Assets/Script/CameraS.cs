using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraS : MonoBehaviour {
    public float m_fSpeed = 5.0f;
    public Camera camera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    public void CameraMove()
    {
        float fVertical = Input.GetAxis("Vertical");
        float fHorizontal = Input.GetAxis("Horizontal");
        float fZaxis = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(fVertical) > 0 || Mathf.Abs(fHorizontal) > 0 || Mathf.Abs(fZaxis) > 0)
        {
            float fYTranslation = fVertical * m_fSpeed;
            float fXTranslation = fHorizontal * m_fSpeed;
            float fZTranslation = fZaxis * m_fSpeed;
            fXTranslation *= Time.deltaTime;
            fYTranslation *= Time.deltaTime;
            //fZTranslation *= Time.deltaTime;
            transform.Translate(fXTranslation, fYTranslation, fZTranslation);
        }

        Vector3 limitmap;
        limitmap.x = Mathf.Clamp(transform.position.x, -6, (float)6);
        limitmap.y = Mathf.Clamp(transform.position.y, (float)-6, (float)6);
        limitmap.z = Mathf.Clamp(transform.position.z, -10, -10);
        transform.position = limitmap;

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
