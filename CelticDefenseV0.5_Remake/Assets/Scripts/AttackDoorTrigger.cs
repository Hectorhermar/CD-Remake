using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDoorTrigger : MonoBehaviour {

    //Radio del cuadrado de detección
    public float radius = 2f;

    //Si encuentra puerta se pone a true
    public bool foundDoor;
    
    //variable del tiempo de la próxima actualización
    public float updateRate=0.5f;

    //Color de la caja del gizmo de detección
    public Color32 gizmoColor = Color.red;

    //variable interna para control de la próxima actualización
    private float nextTime;

    private EnemyAttackControl eAC;

    // Use this for initialization
    void Start()
    {
        eAC = GetComponent<EnemyAttackControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //raciono las llamadas al procedimiento
        //para optimizar el juego
        UpdateRate();
    }

    private void UpdateRate()
    {
        // Llamo al conteo de enemigos solo cada updateRate
        // y no cada Frame Update
        if (Time.time >= nextTime)
        {
            //Este es el procedimiento que se llama
            CheckDoor(transform.position, radius);

            //Actualizo las variables de conteo de Update
            print("Next Update");
            nextTime += updateRate;
            if (Time.time >= nextTime)
                nextTime = Time.time + updateRate;
        }
    }

    void CheckDoor(Vector3 center, float radius)
    {
        //Chequea si hay una puerta cerca y la ataca si está en rango
        Collider[] hitColliders = Physics.OverlapBox(center, new Vector3(radius / 2, radius / 2, radius / 2));
        int i = 0;
        foundDoor = false;
   
        while (i < hitColliders.Length)
        {          
            if (hitColliders[i].transform.tag == "Wall")
            {
                foundDoor = true;
            }
            i++;
        }

        if (foundDoor == true)
        {
            eAC.attack = true;
        }
        else
        {
            eAC.attack = false;
        }
    }

    void OnDrawGizmos()
    {
        // Dibuja un gizmo con el radio del cubo contador 
        // en la posición del objeto local
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(transform.position, new Vector3(radius, radius, radius));
    }

}
