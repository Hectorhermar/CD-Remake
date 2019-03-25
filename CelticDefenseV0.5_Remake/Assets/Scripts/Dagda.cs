using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagda : MonoBehaviour
{

    public GameObject menuTower;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame


    public void OnMouseExit()
    {


        Debug.Log("Dagda");
        menuTower.SetActive(false);

    }


}
