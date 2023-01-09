using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpidaStateMachine : MonoBehaviour
{
    public Stats statScript;
    public Animator anim;
    public Transform player;
    public GameObject Gunt;
      float motionSmoothTime = .1f;
      public NavMeshAgent enemy;
      public SpiderEvents eventsScript;

    IEnumerator Start()
    {
      eventsScript = gameObject.GetComponent<SpiderEvents>();
     statScript = gameObject.GetComponent<Stats>();
     anim = gameObject.GetComponent<Animator>();
     while (true)
     {
     //  transform.LookAt(player);
       //Quaternion rotation = Quaternion.Euler(0,30,0);

       yield return new WaitForSeconds (1f);
   //    var rotation = Quaternion.LookRotation(player.position - transform.position);
     //  transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
       anim.SetInteger ("AttackIndex" , Random.Range(0,3));


   //   transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);
    //   yield return new WaitForSeconds (0.5f);
       anim.SetTrigger("Attack");
  //    anim.SetBool("CanAttack" , false);
     anim.SetFloat("Speed" , 0);

     }
    }

    // Update is called once per frame
    void Update()
    {
      if (statScript.health>0)
    {
      transform.LookAt(2 * transform.position - player.position);
    }
    if ((Vector3.Distance(gameObject.transform.position, Gunt.transform.position) > 2) && (eventsScript.isAttacking == false) )
      {
       anim.SetBool("CanAttack" , false);
        anim.SetFloat("Speed" , 1);
      //  float speed1 = enemy.velocity.magnitude / enemy.speed;
      //  anim.SetFloat("Speed" , speed1 , motionSmoothTime , Time.deltaTime);
        if (statScript.health>0)
        {

          enemy.SetDestination(player.position);
        }


        //  var rotation = Quaternion.LookRotation(player.position - transform.position);
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);

        }
        if(Vector3.Distance(gameObject.transform.position, Gunt.transform.position) <= 4)
        {

          anim.SetBool("CanAttack" , true);
        //  anim.SetFloat("Speed" , 0);

        }
    // if (statScript.health < 0.5)
    // {
      // anim.SetBool("Dead" , true);
  //   }
//    }
}
void OnTriggerEnter (Collider other)
{
  if (other.gameObject.tag == "ZSlow")
  {
    gameObject.GetComponent<NavMeshAgent>().speed = 0.8f;
   StartCoroutine(speedback());
  }
}
void OnTriggerExit (Collider other)
{
  if (other.gameObject.tag == "ZSlow")
  {
    gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;
  }
}
IEnumerator speedback ()
{
  yield return new WaitForSeconds (9.1f);
  gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;
}
}
