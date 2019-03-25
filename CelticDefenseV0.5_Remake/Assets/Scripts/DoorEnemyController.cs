using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DoorEnemyController : MonoBehaviour {



    //Radio de detección
    public float radiusDistance = 2f;

    //Posición del trigger de la puerta
    private Vector3 triggerPos;

    //Offset del trigger en la pos X
    public float triggerPosOffsetX;

    // Actualización de la comprobación en segundos
    public float updateRate = 1f;
    
    //Salud de la puerta
    public float doorHealth = 100;

    //Ratio de daño a la puerta por enemigo
    public float doorDamageRate = 1f;

    //Variable de muerte de la puerta
    public bool dead=false;

    //private NavMeshObstacle _obstacle;

    //Objeto físico de la puerta (para su destrucción)
   // public GameObject doorObject;

    //Color de la caja del gizmo de detección
    public Color32 gizmoColor = Color.red;

    //Número de enemigos
    public int enemyNumber;

    //Variables de control de tiempo y daño
    private float nextTime;
    private float nextTimeDamage;
    public float doorDamageRateMod;
    public bool atacantesDeshabilitados;

    //Texto de % de salud
    //private Text doorText;
    
        //Prefab de la explosion del muro
    public GameObject wallExplossionPrefab;



    // Use this for initialization
    void Start ()
    {
        //Inicializo variables
        doorDamageRateMod = doorDamageRate;
        //doorText = GetComponentInChildren<Text>();
        //Posición del Trigger de la puerta
        //_obstacle = GetComponent<NavMeshObstacle>();
        UpdateTriggerPos();
    }

    private void UpdateTriggerPos()
    {
        //Este método cambia de posición en el eje X el trigger de la puerta

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        triggerPos = new Vector3((x + triggerPosOffsetX), y, z);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Posición del Trigger de la puerta
        UpdateTriggerPos();
        //Actualizo el daño a la puerta
        CheckDamage();
        //Actualizo conteo de enemigos en rango
        UpdateCount();     
        //Compruebo si la puerta aun tiene salud
        CheckDead();
	}
   
    private void CheckDamage()
    {
        //Si hay enemigos atacando...
        if (enemyNumber > 0)
        {
           
            //Compruebo daño
            MakeDamage();
        }

        if (doorHealth <= 0)
        {
            //Si no le queda salud a la puerta la destruyo
            dead = true;
            // atacantesDeshabilitados = true;
          

        }
    }

    private void MakeDamage()
    {
        if (Time.time >= nextTimeDamage)
        {

            //Actualizo la cantidad de daño según los enemigos que estén en rango
            doorDamageRateMod = doorDamageRate * enemyNumber;

            //Actualizo la salud de la puerta según el daño
            doorHealth = doorHealth - doorDamageRateMod;

            //Actualizo el texto de la salud de la puerta
          //  UpdateText();
            //Actualizo el nuevo tiempo
            nextTime = Time.time + doorDamageRate;
        }
    }

    private void UpdateCount()
    {       
        // Llamo al conteo de enemigos solo cada updateRate
        // y no cada Frame Update
        if (Time.time >= nextTime)
        {
            //Este es el procedimiento que se llama
            CountEnemies(triggerPos, radiusDistance);

            //Actualizo las variables de conteo de Update
            print("Next Update");
            nextTime += updateRate;
            if (Time.time >= nextTime)
                nextTime = Time.time + updateRate;
        }
    }
 
    void CountEnemies(Vector3 center, float radius)
    {
        print("void CountEnemies");
        //Contador de enemigos en rango (por collider y tag)

        Collider[] hitColliders = Physics.OverlapBox(center, new Vector3(radius, radius, radius));
        int i = 0;
        enemyNumber = 0;
        List<int> objID = new List<int>();    
        
        while (i <hitColliders.Length)
            {
            GameObject colObj = hitColliders[i].transform.gameObject;
            
            if (colObj.transform.CompareTag("Attack"))
            {
              
                print(" if (colObj.transform.tag==Attack)");
                if (!objID.Contains(colObj.GetInstanceID()))
                {
                    print("if (!objID.Contains(colObj.GetInstanceID()))");
                    //Si el zombie está atacando sumo 1
                    //A los enemigos que atacan la puerta
                    EnemyAttackControl eAC = colObj.GetComponent<EnemyAttackControl>();
                  //  NavMeshObstacle obstacle = GetComponentInParent<NavMeshObstacle>();
                   //               obstacle.enabled = true;
                    if (dead == false)
                    {
                        //Objeto muro al que miro al atacar
                        eAC.wall = this.gameObject;
                   //    obstacle.enabled = true;
                        print("Entra en dead=false");
                       // if (eAC.attack == false)
                        //{
                           // eAC.attack = true;
                           
                           
                                                        
                        //}
                    }

                    else
                    {
                        print("Entra en dead=true");

                        //Objeto muro al que dejo de mirar
                        eAC.attack = false;
                            print("Desataca!");
                        eAC.wall = null;


                    }
                   

                    objID.Add(colObj.GetInstanceID());
                    enemyNumber++;
                 
                    print("INSTANCE CONSEGUIDO");
                     
                }
            }i++;
            
               
            }
        if (dead == true)
            {
           // atacantesDeshabilitados = true;

        }
        }

    //  private void UpdateText()
    // {
    //  doorText.text = System.Math.Round(doorHealth, 1).ToString() + "%";
    // }

    private void CheckDead()
    {
        if (dead == true)
        {
           // if (atacantesDeshabilitados == true)
            //Solo destruyo la puerta si previamente he desatacado a los atacantes
            {
                //TODO
                Instantiate(wallExplossionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
        }
    }

    void OnDrawGizmos()
    {
        // Dibuja un gizmo con el radio del cubo contador 
        // en la posición del objeto local
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(triggerPos, new Vector3(radiusDistance, radiusDistance, radiusDistance));
    }

}
