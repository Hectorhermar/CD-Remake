using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Contador_Monedas;


public class Lugh : MonoBehaviour
{

    public GameObject menuTower;
    public GameObject TorreEnConstruccion;
    public Vector3 posicion;
    public GameObject Torre;
    public Transform TowerPosition;
    public float PrecioLu;
  //  private Animator anim;
   // private bool BotonActivado=false;
    public GameObject FraseSinOro;
    
   

    // Start is called before the first frame update
    void Start()
    {
       // anim = GetComponent<Animator>();
        
    }
    

    // Update is called once per frame


    public void OnMouseExit()
    { Debug.Log("Lugh");
       
        if (scoreValue<=49f)
        {
            FraseSinOro.SetActive(true);
            Invoke("desactivaFrase",1f);
            
        }
        
        
        
        
        if (scoreValue >= 50f)
        {//anim.SetBool("Enabled",true);
          GameObject construyendo =  Instantiate(TorreEnConstruccion, TowerPosition.position + posicion, Quaternion.identity);
            Invoke("TorreHecho", 5f);
            Invoke("desactivaHud",.5f);
            scoreValue -= 50f;
            Destroy(construyendo,5f);
           // anim.SetBool("Enabled",false);
            //  Destroy(gameObject);
        }

       
    }
            
    

    void TorreHecho()
    {
       GameObject nuevatorre= Instantiate(Torre, TowerPosition.position + posicion, Quaternion.identity);
    }

    void desactivaHud()
    {
        menuTower.SetActive(false);
    }
    
    void desactivaFrase()
    {
        FraseSinOro.SetActive(false);
    }
    }

    

