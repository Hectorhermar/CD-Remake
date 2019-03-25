using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTower : MonoBehaviour
{

    public GameObject menuTower;
    
    // public GameObject TorreEnConstruccion;
    // public Vector3 posicion;
    // public GameObject Torre;
  //  public GameObject tower;



    // Start is called before the first frame update
    void Start()
    {
        menuTower.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        // AparecerMenu();
      //  if (Input.GetMouseButtonDown(0)&& menuTower)
     //   {
      //     MantenerPosicion();
      //  }


    }


    private void OnMouseDown()
    {
        menuTower.SetActive(true);
        menuTower.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

   /* void MantenerPosicion()
    {
        menuTower.transform.position=new Vector3(tower.transform.position.x,tower.transform.position.y,0f);
    }
*/
    private void OnMouseUp()
    {

        print("TorreConstruida");

        Invoke("desactivaHud",.5f);
        

    }

    void desactivaHud()
    {
        menuTower.SetActive(false);
       // Destroy(gameObject,5f);
    }

}
/*
    void AparecerMenu()
    {
        if (Input.GetMouseButtonDown(0))
        {

            menuTower.SetActive(true);
            menuTower.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
        
       if (Input.GetMouseButtonUp(0))
        {
            menuTower.SetActive(false);
        }
        }
    }

*/

