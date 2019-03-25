using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NavMeshControl : MonoBehaviour
{

    public GameObject Target;

    private NavMeshAgent nMa;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        nMa = GetComponent<NavMeshAgent>();
        Target =GameObject.FindGameObjectWithTag("Objetivo");
        SetTarget(Target);
      // NavMeshPath path=new NavMeshPath();
       // nMa.CalculatePath(transform.position, path);
       
      
    }

    void findwall()
    {
        GameObject wall=GameObject.FindGameObjectWithTag("Wall");
        
        if (wall==null)
        {
            Target =GameObject.FindGameObjectWithTag("Objetivo");
            nMa.SetDestination(Target.transform.position);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        findwall();
    }

    public void SetTarget(GameObject gO)
    {
        if (gO != null)
        {
            nMa.Warp(transform.position);
            nMa.SetDestination(gO.transform.position);
        }

        else
        {
            nMa.Warp(transform.position);
           // nMa.Stop();
        }
    }
}
