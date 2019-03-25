using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{

	

	public Transform target;
	public float rango = 15f;
	public Transform Rotador;
	public GameObject ProyectilPrefab;
	public Transform firepoint;
	
	[Header ("Attributes")]
	public float velocidadGiro=10f;
	public float fireRate=1f;
	private float fireCountDown = 0f;
		

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);


	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color=Color.red;
		Gizmos.DrawWireSphere(transform.position,rango);
	}

	void UpdateTarget()
	{
		GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
		float DistanciaMasCorta = Mathf.Infinity;
		GameObject EnemigoMasCercano = null;
		foreach (var enemigo in enemigos)
		{
			float DistanciaAlEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);
			if (DistanciaAlEnemigo < DistanciaMasCorta)
			{
				DistanciaMasCorta = DistanciaAlEnemigo;
				EnemigoMasCercano = enemigo; //.GetComponentInChildren<>();
			}
			
		}

		if (EnemigoMasCercano !=null&&DistanciaMasCorta <=rango)
		{
			target = EnemigoMasCercano.transform;
	
		}

		else
		{ 
			target = null;
			
		}
		

	}
		
			
		
			
	

	// Update is called once per frame
	void Update ()
	{
		if (target == null) return;
//apuntado
		Vector3 dir =  target.position -transform.position ;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = lookRotation.eulerAngles;
		Rotador.rotation =Quaternion.Euler(0f,rotation.y,0f);

		if (fireCountDown <= 0f)
		{
			Shoot();
			fireCountDown = 1f / fireRate;
		}

		fireCountDown -= Time.deltaTime;

	}

	void Shoot()
	{
	GameObject BulletGO=(GameObject)Instantiate(ProyectilPrefab, firepoint.position, firepoint.rotation);
		
		BulletController bullet = BulletGO.GetComponent<BulletController>();

		if (bullet !=null)
		{
			bullet.Seek(target);
		}
	}
	
}
