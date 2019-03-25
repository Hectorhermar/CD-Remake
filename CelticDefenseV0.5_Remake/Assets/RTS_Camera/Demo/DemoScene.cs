using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DemoScene : MonoBehaviour 
{
  

    private void Start()
    {
        Transform camT = Camera.main.transform;
        SetXRotation(camT, 45f);
       
    }

    private void SetXRotation(Transform t, float angle)
    {
        t.localEulerAngles = new Vector3(angle, t.localEulerAngles.y, t.localEulerAngles.z);
    }
}
