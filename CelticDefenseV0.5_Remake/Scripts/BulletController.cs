using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class BulletController : MonoBehaviour
{

	// Use this for initialization
	private Transform target;
	private Esqueleto Skeleton;
	public float speed = 1000f;



	//public GameObject Rag;
	//private DestroyRag dR;


	private void Start()
	{
		Destroy(gameObject, 1.1f);	
		//dR = GetComponent<DestroyRag>();
	}

	public void Seek(Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	//
	private void destruyeBala()
	{
		Destroy(gameObject);
	}

	void Update()
	{
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float DistanciaFotograma = speed * Time.deltaTime;

		if (dir.magnitude <= DistanciaFotograma)
		{
		Destroy(gameObject);
			return;

		}

		transform.Translate(dir.normalized * DistanciaFotograma, Space.World);
		

	}

	void FixedUpdate()
	{


	}

	private void CompruebaCollision()
	{
		
		
		
	}
	
	private void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponentInParent<Esqueleto>().saludEnemigo > 0 )
		{
			Skeleton = other.GetComponentInParent<Esqueleto>();
			Skeleton.saludEnemigo-=50f;
			print("Enemigo hit, salud:"+Skeleton.saludEnemigo.ToString());
			Skeleton.barra_Salud.fillAmount = Skeleton.saludEnemigo / 100f;
			
			//E.numVidas--;
		}
		
			//if (E.numVidas == 0 || E.numVidas < 0)
		if (Skeleton.saludEnemigo == 0f)
		{
			//Desactivo barra de salud
			    Skeleton.barra_Salud.enabled = false;
			
				//PASAR/ENVIAR  MONEDAS DESDE AQUÍ AL CANVAS
				Contador_Monedas.scoreValue += Skeleton.numMonedas;
				
				//other.GetComponent<DestroyRag>()
				//other.GetComponent<SphereCollider>().enabled = false;
				this.GetComponent<SphereCollider>().enabled = false;
				//other.GetComponentInParent<CapsuleCollider>().enabled = false;
				other.GetComponentInParent<NavMeshControl>().enabled = false;
				other.GetComponentInParent<NavMeshAgent>().enabled = false;
				// other.GetComponentInParent<SphereCollider>().enabled = false;
				other.GetComponentInParent<Animator>().enabled = false;
				
				//Instantiate(Rag, other.transform.position,transform.rotation);
				other.GetComponentInParent<DestroyRag>().isRagdoll = true;
				
				//Destruyo la colisión del enemigo (colisión solo)
				Destroy(other.gameObject);
				
				//Destruyo la bala
				Destroy(gameObject);	
		}
		
		if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponentInParent<Esqueleto>().saludEnemigo <= 0)

		{
				
			//other.GetComponent<DestroyRag>()
			//other.GetComponent<SphereCollider>().enabled = false;
			this.GetComponent<SphereCollider>().enabled = false;
			//other.GetComponentInParent<CapsuleCollider>().enabled = false;
			other.GetComponentInParent<NavMeshControl>().enabled = false;
			other.GetComponentInParent<NavMeshAgent>().enabled = false;
			// other.GetComponentInParent<SphereCollider>().enabled = false;
			other.GetComponentInParent<Animator>().enabled = false;
			//Desactivo barra de salud
			Skeleton.barra_Salud.enabled = false;
			//Instantiate(Rag, other.transform.position,transform.rotation);
			other.GetComponentInParent<DestroyRag>().isRagdoll = true;
			Destroy(other.gameObject);
			Destroy(gameObject);

		}
	}
}

