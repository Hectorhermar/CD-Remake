using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DestroyRag : MonoBehaviour {

	// Use this for initialization

	private Rigidbody rB;
	public Vector3 myvector;
	public bool isRagdoll;
	private NavMeshControl nMMC;
	private NavMeshAgent nMA;
	private Animator anim;
	private CapsuleCollider cC;
	public GameObject DP;
	private bool spawnedCoin;
	
	
	void Start ()
	{
		spawnedCoin = false;
		nMMC = GetComponent<NavMeshControl>();
	//	cC = GetComponent<CapsuleCollider>();
		anim = GetComponent<Animator>();
		nMA = GetComponent<NavMeshAgent>();
		DisablePhysics();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (spawnedCoin!=true)
		{
			CheckRagdollState();
			
		}
		else
		{nMA.enabled = false;
			return;
		}

	}

	void DestroyMe()
	{
		spawnedCoin = true;
		Invoke("InstanciaMuerte",0f);
		Destroy(gameObject,5f);
	}

	private void CheckRagdollState()
	{
		if (isRagdoll)
		{
			MakeRagdoll();
			
		}
		else
		{
			UnmakeRagdoll();
		}
	}

	private void MakeRagdoll()
	{
		nMMC.enabled = false;
	//	cC.enabled = false;
		anim.enabled = false;
		nMA.enabled = false;
		DestroyMe();
	
		
	}

	private void UnmakeRagdoll()
	{
		nMMC.enabled = true;
	//	cC.enabled = true;
		anim.enabled = true;
//		nMA.enabled = true;
	}

	private void EnablePhysics()
	{
		isRagdoll = true;
	}

	private void DisablePhysics()
	{
		isRagdoll = false;
	}
	void InstanciaMuerte()
	{
		if (spawnedCoin)
		{
			DP.SetActive(true);
			
		}
	
	
	}

}
	

