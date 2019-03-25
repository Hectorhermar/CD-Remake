using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackControl : MonoBehaviour
{
    private Animator anim;

    public bool attack;
    public bool attackOld;
    [HideInInspector]
    public GameObject wall;

  //  private RaycastHit Ray;
   private NavMeshAgent nVa;
    private NavMeshControl nMC;
    private float rayLenght;

    private NavMeshObstacle nMo;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        nVa = GetComponentInParent<NavMeshAgent>();
       nMo = GetComponentInParent<NavMeshObstacle>();
        nMC = GetComponentInParent<NavMeshControl>();
     // rayLenght = 10f;
     //   nMo.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        if (attack == true)
        {
            if(wall!=null)
            transform.LookAt(wall.transform);
        }
        else
        {
            
            nMo.enabled = false;
            nVa.enabled = true;
        }

        if (attack != attackOld)
        {
            if (attack == true)
            {nMo = GetComponentInParent<NavMeshObstacle>();
                nVa.enabled = false;
                nMo.enabled = true;
              //  nMo.enabled = true;
                //    Debug.Log(Ray.collider.name);
                anim.SetBool("Attack", true);
                nMC.SetTarget(null);
            }
            else
            {
                attack = false;
             //   nMo.enabled = false;
                nMo.enabled = false;
                nVa.enabled = true;
                anim.SetBool("Attack", false);
                nMC.SetTarget(nMC.Target);
            }

            attackOld = attack;
        }
    }

    /*  private void OnTriggerEnter(Collider other)
      {
          if (other.gameObject.CompareTag("Wall"))
          {
              print("wallatack");
              anim.SetBool("Attack",true);
          }
          
      }
      */
}
