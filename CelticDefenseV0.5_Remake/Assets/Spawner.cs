using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject EnemyPrefab;

	public float TiempoQueTardaEnEmpezar;

	public float TiempoEntreSpawnDeMinion;

	public float MaxMinions;

	public float MinionsActuales;
	

	public Transform Objective;
	// Use this for initialization
	void Start () {
		
		
			InvokeRepeating("Spawnea",TiempoQueTardaEnEmpezar,TiempoEntreSpawnDeMinion);
			
		
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void Spawnea()
	{
		if (MinionsActuales < MaxMinions)
		{
			Instantiate(EnemyPrefab,Objective.position,Objective.rotation);MinionsActuales++;
		}

		
	}
}
	
