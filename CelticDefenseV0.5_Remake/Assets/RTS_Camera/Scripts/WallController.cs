using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{

  //  public GameObject Wait;
    public GameObject Wall;
    public Vector3 position;

    public Vector3 position2;
    public bool alreadySpawned;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void muroHecho()
    {
        Instantiate(Wall,transform.position,transform.rotation);
    }

    private void OnMouseDown()
    {
        //Solo instancio una vez
        if(alreadySpawned==false)
        {
          //  Instantiate(Wait, transform.position, Quaternion.identity);
            Invoke("muroHecho", 5f);
            alreadySpawned = true;
        }
    }
}
