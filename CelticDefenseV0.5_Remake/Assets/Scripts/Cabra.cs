using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabra : MonoBehaviour
{
    //NUMERO VIDAS ENEMIGO
    //public int numVidas = 2;
    //public int numMaxVidas;

    //SALUD FLOAT
    public float saludEnemigo = 200f;
   // public GameObject Rig;

   // private Rigidbody[] rBs;
  //  private Collider[] cols;

//BUFF
//public int buff;

//Barra salud
[Header("BARRA")] public Image barra_Salud;

    //MONEDAS
    public int numMonedas = 8;
    private BulletController bC;
/*
    private void Start()
    {
      //  CapturaComponentes();
      //  DeshabilitaCols();
    }

   / private void CapturaComponentes()
    {
        rBs = Rig.GetComponentsInChildren<Rigidbody>();
        cols = Rig.GetComponentsInChildren<Collider>();
    }

    public void DeshabilitaCols()
    {     
        foreach (Rigidbody rB in rBs)
        {
            rB.isKinematic = true;
        }

        foreach (Collider col in cols)
        {
            col.enabled = false;
        }
    }

    public void HabilitaCols()
    {      

        foreach (Rigidbody rB in rBs)
        {
            rB.isKinematic = false;
        }

        foreach (Collider col in cols)
        {
            col.enabled = true;
        }
    }*/
}

