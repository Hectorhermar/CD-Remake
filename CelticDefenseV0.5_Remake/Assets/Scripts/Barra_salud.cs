using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Barra_salud : MonoBehaviour
{
    public Camera my_camera;
    private Image Healthbar;
    
    
    void Update()
    {
        transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.back,
            my_camera.transform.rotation * Vector3.down);
    }
}
