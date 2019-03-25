using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public float doorOpenAngle = 90.0f;
    public float doorCloseAngle = 0.0f;
    public float doorAnimSpeed = 2.0f;
    public float distanceToPlayer = 5f;
    //false = cerrada, true = abierta
    public bool isDoorOpen = false;
    private bool isDoorOpenOld;

    private Quaternion doorOpen = Quaternion.identity;
    private Quaternion doorClose = Quaternion.identity;
    private Transform playerTrans = null;
    //for Coroutine, when start only one
    private bool doorGo = false;
    //Distancia a la que el player abrirá la puerta
   

    void Start()
    {
        Inicializame();
    }
    void Update()
    {
        //If press F key on keyboard
        if (Input.GetKeyDown(KeyCode.F) && !doorGo)
        {
            OperaPuertaPlayer();
        }

        //Si ha cambiado la variable de isDoorOpen Opero la puerta
        if ((isDoorOpen != isDoorOpenOld) && !doorGo)
        {
            OperaPuerta();
        }
    }

    private void OperaPuertaPlayer()
    {
        //Calculate distance between player and door
        if (Vector3.Distance(playerTrans.position, this.transform.position) < 5f)
        {
            if (isDoorOpen)
            { //close door
                StartCoroutine(this.moveDoorPlayer(doorClose));
            }
            else
            { //open door
                StartCoroutine(this.moveDoorPlayer(doorOpen));
            }
        }
    }

    private void OperaPuerta()
    {     
           if (isDoorOpen)
            { //close door
                StartCoroutine(this.moveDoor(doorOpen));
            }
            else
            { //open door
                StartCoroutine(this.moveDoor(doorClose));
            }
        
    }
    private void Inicializame()
    {
        //isDoorOpen = false; //door is open, maybe change

        //Inicialización para los ängulos de la puerta
        //Cerrada
        doorOpen = Quaternion.Euler(0, doorOpenAngle, 0);
        //Abierta
        doorClose = Quaternion.Euler(0, doorCloseAngle, 0);
        //Encuentra al Player para calcular las distancias
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        isDoorOpenOld = isDoorOpen;
        if (isDoorOpen) OperaPuerta();
    }

    public IEnumerator moveDoorPlayer(Quaternion dest)
    {
        //Al estar abriendo o cerrando bloqueo la llamada a este procedimiento
        doorGo = true;
        //Check if close/open, if angle less 4 degree, or use another value more 0
        while (Quaternion.Angle(transform.localRotation, dest) > 4.0f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);
            //UPDATE 1: add yield
            yield return null;
        }
        //Cambio el estado de la puerta
        isDoorOpen = !isDoorOpen;
        isDoorOpenOld = isDoorOpen;
        //Desbloqueo la llamada a este procedimiento
        doorGo = false;
        //UPDATE 1: add yield
        yield return null;
    }

    public IEnumerator moveDoor(Quaternion dest)
    {
        //Al estar abriendo o cerrando bloqueo la llamada a este procedimiento
        doorGo = true;
        //Check if close/open, if angle less 4 degree, or use another value more 0
        while (Quaternion.Angle(transform.localRotation, dest) > 4.0f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);
            //UPDATE 1: add yield
            yield return null;
        }
        isDoorOpenOld = isDoorOpen;
        //Desbloqueo la llamada a este procedimiento
        doorGo = false;
        //UPDATE 1: add yield
        yield return null;
    }
}
