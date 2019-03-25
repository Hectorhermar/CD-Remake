using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Triton : MonoBehaviour
{
    
    public float saludEnemigo = 60f;
    
    //BUFF
    //public int buff;

    //Barra salud
    [Header("BARRA")]
    public Image barra_Salud;

    private Rigidbody rB;
    private NavMeshAgent nMa;
    
    //MONEDAS
    public int numMonedas = 8;
    private BulletController bC;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponentInParent<Rigidbody>();
        nMa = GetComponentInParent<NavMeshAgent>();
        

    }

    private void checkdead()
    {
        if (saludEnemigo<=0)
        {
            nMa.enabled = false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkdead();
    }
}
