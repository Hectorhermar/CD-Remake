using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Esqueleto : MonoBehaviour
{
    //NUMERO VIDAS ENEMIGO
    //public int numVidas = 2;
    //public int numMaxVidas;

    //SALUD FLOAT
    public float saludEnemigo = 100f;
    
    //BUFF
    //public int buff;

    //Barra salud
    [Header("BARRA")]
    public Image barra_Salud;
    
    //MONEDAS
    public int numMonedas = 8;
    private BulletController bC;
    
    
    // Start is called before the first frame update
    void Start()
    {
       // barra_Salud = GameObject.Find("Barra_salud").GetComponent<Image>();
        /*
         buff = Random.Range(-10, 10);
        print("BUFF ES:" + buff);
        if (buff >= 9)
        {
            //numVidas = Random.Range(4,8);
            saludEnemigo = Random.Range(150, 200);
            numMonedas = 15;
            print("BUFEADO");
            //HACER GRANDE BUFF
            transform.localScale += new Vector3(0.1F, 0.5f, 0);
        }*/

    }
 
    
    
    // Update is called once per frame
    void Update()
    {
        /*
        barra_Salud.fillAmount = saludEnemigo / 100f;
        if (barra_Salud.fillAmount < 0 || barra_Salud.fillAmount == 0)
        {
            Destroy(gameObject);
            Destroy(barra_Salud);
        }
        */
    }        
}
