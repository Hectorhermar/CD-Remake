using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestroyRag : MonoBehaviour {

	// Use this for initialization

	private Rigidbody rB;
	private Vector3 myvector;
	public bool isRagdoll;
	private NavMeshMouseController nMMC;
	private NavMeshAgent nMA;
	private Animator anim;
	private CapsuleCollider cC;
	
	void Start ()
	{
		nMMC = GetComponent<NavMeshMouseController>();
		cC = GetComponent<CapsuleCollider>();
		anim = GetComponent<Animator>();
		nMA = GetComponent<NavMeshAgent>();
		DisablePhysics();
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckRagdollState();

	}

	void DestroyMe()
	{
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
		cC.enabled = false;
		anim.enabled = false;
		nMA.enabled = false;
		DestroyMe();
	}

	private void UnmakeRagdoll()
	{
		nMMC.enabled = true;
		cC.enabled = true;
		anim.enabled = true;
		nMA.enabled = true;
	}

	private void EnablePhysics()
	{
		isRagdoll = true;
	}

	private void DisablePhysics()
	{
		isRagdoll = false;
	}
	
	
}
