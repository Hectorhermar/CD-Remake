using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.AI;
using static Contador_Monedas;


public class BulletController : MonoBehaviour
{

	// Use this for initialization
	private Transform target;
	private Esqueleto Skeleton;
	private Ogro ogro;
	private Cabra cabra;
	private Triton triton;
	public float speed = 1000f;
	private Transform ID;
	public GameObject Blood;


	private void Start()
	{
		
		Destroy(gameObject, 2.1f);
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


	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("hit " + other.gameObject);

		if (other.gameObject.CompareTag("Enemy"))
		{
			GameObject blood=Instantiate(Blood, transform.position, Quaternion.identity);
			Destroy(blood,2f);
			ID = other.GetComponent<Transform>();

			int monster =EncuentraID(ID);


			switch (monster)
			{
				case 1:
					if (other.gameObject.GetComponentInParent<Ogro>().saludEnemigo >1)
					{


						print("Ogro");
						ogro = other.GetComponentInParent<Ogro>();
						ogro.saludEnemigo -= 25f;
						print("Enemigo hit, salud:" + ogro.saludEnemigo.ToString());
						ogro.barra_Salud.fillAmount = ogro.saludEnemigo / 100f;
					}
					
					{
						if (other.gameObject.GetComponentInParent<Ogro>().saludEnemigo <= 0)
						{
							Contador_Monedas.scoreValue += ogro.numMonedas;
							this.GetComponent<SphereCollider>().enabled = false;
							other.GetComponentInParent<NavMeshControl>().enabled = false;
							other.GetComponentInParent<NavMeshAgent>().enabled = false;
							other.GetComponentInParent<Animator>().enabled = false;

							//Desactivo barra de salud
							ogro.barra_Salud.enabled = false;
							other.GetComponentInParent<DestroyRag>().isRagdoll = true;
							Destroy(other.gameObject);
							Destroy(gameObject);
						}
					}

					break;
				case 2:
					if (other.gameObject.GetComponentInParent<Esqueleto>().saludEnemigo > 1)
					{


						print("Esqueleto");
						Skeleton = other.GetComponentInParent<Esqueleto>();
						Skeleton.saludEnemigo -= 25f;
						print("Enemigo hit, salud:" + Skeleton.saludEnemigo.ToString());
						Skeleton.barra_Salud.fillAmount = Skeleton.saludEnemigo / 100f;
						

					}
					
					{
						if (other.gameObject.GetComponentInParent<Esqueleto>().saludEnemigo <= 0)
						{
							scoreValue += Skeleton.numMonedas;
							this.GetComponent<SphereCollider>().enabled = false;
							other.GetComponentInParent<NavMeshControl>().enabled = false;
							other.GetComponentInParent<NavMeshAgent>().enabled = false;
							other.GetComponentInParent<Animator>().enabled = false;

							//Desactivo barra de salud
							Skeleton.barra_Salud.enabled = false;
							other.GetComponentInParent<DestroyRag>().isRagdoll = true;
							Destroy(other.gameObject);
							Destroy(gameObject);
						}
					}
					break;
				case 3:
					if (other.gameObject.GetComponentInParent<Cabra>().saludEnemigo > 1)
					{


						print("Cabra");
						cabra= other.GetComponentInParent<Cabra>();
						cabra.saludEnemigo -= 25f;
						print("Enemigo hit, salud:" + cabra.saludEnemigo.ToString());
						cabra.barra_Salud.fillAmount = cabra.saludEnemigo / 100f;
						

					}
					
				{
					if (other.gameObject.GetComponentInParent<Cabra>().saludEnemigo <= 0)
					{
						scoreValue += cabra.numMonedas;
						this.GetComponent<SphereCollider>().enabled = false;
						other.GetComponentInParent<NavMeshControl>().enabled = false;
						other.GetComponentInParent<NavMeshAgent>().enabled = false;
						other.GetComponentInParent<Animator>().enabled = false;

						//Desactivo barra de salud
						cabra.barra_Salud.enabled = false;
						other.GetComponentInParent<DestroyRag>().isRagdoll = true;
						Destroy(other.gameObject);
						Destroy(gameObject);
					}
				}
					break;
				case 4:
					if (other.gameObject.GetComponentInParent<Triton>().saludEnemigo > 1)
					{


						print("Triton");
						triton= other.GetComponentInParent<Triton>();
						triton.saludEnemigo -= 25f;
						print("Enemigo hit, salud:" + triton.saludEnemigo.ToString());
						triton.barra_Salud.fillAmount = triton.saludEnemigo / 100f;
						

					}
					
				{
					if (other.gameObject.GetComponentInParent<Triton>().saludEnemigo <= 0)
					{
						scoreValue += triton.numMonedas;
						this.GetComponent<SphereCollider>().enabled = false;
						other.GetComponentInParent<NavMeshControl>().enabled = false;
						other.GetComponentInParent<NavMeshAgent>().enabled = false;
						other.GetComponentInParent<Animator>().enabled = false;

						//Desactivo barra de salud
						triton.barra_Salud.enabled = false;
						other.GetComponentInParent<DestroyRag>().isRagdoll = true;
						Destroy(other.gameObject);
						Destroy(gameObject);
					}
				}
					break;
			}



		}

		//E.numVidas--;
	}

	private int EncuentraID(Transform id)
	{
		int iden;
		var I = id.GetChild(0);
		if (I.CompareTag("Ogro"))
		{
			iden = 1;
				return iden;
		}

		if (I.CompareTag("Esqueleto"))
		{
			iden = 2;
			return iden;
		}

		if (I.CompareTag("Cabra"))
		{
			iden = 3;
			return iden;
		}

		if (I.CompareTag("Triton"))
		{
			iden = 4;
			return iden;
		}

		return 0;
	}
	
	
	
	
}




/*	if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponentInParent<Esqueleto>().saludEnemigo <= 0)

	{//PASAR/ENVIAR  MONEDAS DESDE AQUÍ AL CANVAS
		Contador_Monedas.scoreValue += Skeleton.numMonedas;

		
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
/*
	if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponentInParent<Esqueleto>().saludEnemigo > 0)
	{
		Skeleton = other.GetComponentInParent<Esqueleto>();
		Skeleton.saludEnemigo -= 50f;
		print("Enemigo hit, salud:" + Skeleton.saludEnemigo.ToString());
		Skeleton.barra_Salud.fillAmount = Skeleton.saludEnemigo / 100f;
	}

	if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponentInParent<Esqueleto>().saludEnemigo <= 0)

	{

		//other.GetComponent<DestroyRag>()
		//other.GetComponent<SphereCollider>().enabled = false;
		this.GetComponent<SphereCollider>().enabled = false;
		//other.GetComponentInParent<CapsuleCollider>().enabled = false;
		other.GetComponentInParent<NavMeshControl>().enabled = false;
		other.GetComponentInParent<NavMeshAgent>().enabled = false;
		// other.GetComponentInParent<SphereCollider>().enabled = false;}
		other.GetComponentInParent<Animator>().enabled = false;
		//Desactivo barra de salud
		Skeleton.barra_Salud.enabled = false;
		//Instantiate(Rag, other.transform.position,transform.rotation);
		other.GetComponentInParent<DestroyRag>().isRagdoll = true;
		Destroy(other.gameObject);
		Destroy(gameObject);

*/
//
/*
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
		*/
