using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableHud : MonoBehaviour
{
    private Animator anim;
    private 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void disableHud()
    {
        anim.enabled = false;
    }

    void enableHud()
    {
        anim.enabled = true;
    }
}
