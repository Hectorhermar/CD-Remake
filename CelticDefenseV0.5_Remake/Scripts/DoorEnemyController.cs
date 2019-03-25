using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorEnemyController : MonoBehaviour
{

    //Radio de detección
    public float radiusDistance = 2f;

    // Actualización de la comprobación en segundos
    public float updateRate = 1f;
    
    //Salud de la puerta
    public float doorHealth = 100;

    //Ratio de daño a la puerta por enemigo
    public float doorDamageRate = 1f;

    //Variable de muerte de la puerta
    public bool dead=false;

    //Objeto físico de la puerta (para su destrucción)
    public GameObject doorObject;

    //Color de la caja del gizmo de detección
    public Color32 gizmoColor = Color.red;

    //Número de enemigos
    private int enemyNumber;

    //Variables de control de tiempo y daño
    private float nextTime;
    private float nextTimeDamage;
    public float doorDamageRateMod;

    //Texto de % de salud
    private Text doorText;


    // Use this for initialization
    void Start ()
    {
        //Inicializo variables
        doorDamageRateMod = doorDamageRate;
        doorText = GetComponentInChildren<Text>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Actualizo conteo de enemigos en rango
        UpdateCount();
        //Actualizo el daño a la puerta
        CheckDamage();
        //Compruebo si la puerta aun tiene salud
        CheckDead();
    }
    private void CheckDead()
    {
        if (dead == true)
        {
            radiusDistance = 2f;
            //TODO
            //Instantiate Breaked Door...

            //Destruyo el objeto contador y la puerta real
            Destroy(doorObject);
            Destroy(gameObject);

        }
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
            radiusDistance = 2f;
            //Si no le queda salud a la puerta la destruyo
            dead = true;
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
            UpdateText();
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
            CountEnemies(transform.position, radiusDistance);

            //Actualizo las variables de conteo de Update
            print("Next Update");
            nextTime += updateRate;
            if (Time.time >= nextTime)
                nextTime = Time.time + updateRate;
        }
    }
 
    void CountEnemies(Vector3 center, float radius)
    {
        //Contador de enemigos en rango (por collider y tag)

        Collider[] hitColliders = Physics.OverlapBox(center, new Vector3(radius/2, radius/2, radius/2));
        int i = 0;
        enemyNumber = 0;
        List<int> objID = new List<int>();  
        while (i < hitColliders.Length)
            {
            GameObject colObj = hitColliders[i].transform.root.gameObject;
            if (colObj.CompareTag("Enemy"))
            {
                if (!objID.Contains(colObj.GetInstanceID()))
                {
                    //Si el zombie está atacando sumo 1
                    //A los enemigos que atacan la puerta
                    //if (colObj.GetComponentInChildren<EnemyAttackControl>().Attack == true)
                    if (colObj.GetComponentInParent<EnemyAttackControl>().Attack == true)
                    {
                        objID.Add(colObj.GetInstanceID());
                        enemyNumber++;
                        if (doorHealth <= 0)
                        {
                            radiusDistance = 2f;
                        }
                    }
                }
            }       
                i++;
            }
        }
    
    
    private void UpdateText()
    {
        doorText.text = System.Math.Round(doorHealth, 1).ToString() + "%";
    }

    void OnDrawGizmos()
    {
        // Dibuja un gizmo con el radio del cubo contador 
        // en la posición del objeto local
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(transform.position, new Vector3(radiusDistance, radiusDistance, radiusDistance));
    }

}
