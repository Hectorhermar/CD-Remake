using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{

	public GameObject personajecorriendo;
	public float generatorTimer = 2f;
	public float RangoCreacion = 2f;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Creando", 0.0f, generatorTimer);
	}
	
	
	
	// Update is called once per frame
	void Update () {
		Vector3 SpawnPosition = new Vector3(0,0,0);
		SpawnPosition = this.transform.position + Random.onUnitSphere * RangoCreacion;
		SpawnPosition = new Vector3(SpawnPosition.x, this.transform.position.y);

		GameObject enemy = Instantiate(personajecorriendo, SpawnPosition, Quaternion.identity);
	}
}
