using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public GameObject Gaunt;
    public Stats statScript;
    ZSlow slowscript ;
    ZDestroy destscript;
    public bool unslow;
    Animator anim;
    float motionSmoothTime = .1f;
    public GameObject slower;
    public GameObject mutant;
    public GameObject ice;
    Rigidbody rigidbody;
    public float RadiusaroundTarget;
    public int AgentIndex;
    public Stats playerstats;
    void Start()
    {
      playerstats = Gaunt.gameObject.GetComponent<Stats>();
    //  AgentIndex = playerstats.TargetsNumber;
      playerstats.TargetsNumber = playerstats.TargetsNumber + 1;
      rigidbody = gameObject.GetComponent<Rigidbody>();
     statScript = gameObject.GetComponent<Stats>();
     slowscript = gameObject.GetComponent<ZSlow>();
     destscript = gameObject.GetComponent<ZDestroy>();
     anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    //  AgentIndex = playerstats.TargetsNumber;
    if (statScript.health>0)
    {
      transform.LookAt(player);
      Quaternion rotation = Quaternion.Euler(0,30,0);
    }
  //  transform.LookAt(player);
  //  Quaternion rotation = Quaternion.Euler(0,30,0);

      float speed1 = enemy.velocity.magnitude / enemy.speed;
      anim.SetFloat("Speed" , speed1 , motionSmoothTime , Time.deltaTime);
      if ((statScript.health>0) && anim.GetBool("Basic Attack") == false)
      {
        enemy.SetDestination (new Vector3 (
        player.position.x + RadiusaroundTarget * Mathf.Cos(2*Mathf.PI * AgentIndex / playerstats.TargetsNumber) ,
        player.position.y,
        player.position.z + RadiusaroundTarget * Mathf.Sin(2*Mathf.PI * AgentIndex / playerstats.TargetsNumber)
        ));
    //    transform.LookAt(player);
      //  Quaternion rotation = Quaternion.Euler(0,30,0);
      }
      if (statScript.health<0.5)
      {
        rigidbody.isKinematic = true;
        rigidbody.detectCollisions = false;
          playerstats.TargetsNumber = playerstats.TargetsNumber - 1;


      }

    //  if (unslow == true)
    //  {
      //  gameObject.GetComponent<NavMeshAgent>().speed = 2;
      //  unslow = false;
      //}

    //  if (gameObject.GetComponent<NavMeshAgent>().speed == 0.8f)
    //  {
      //  anim.SetBool("run" , true);
  //    }
    //  else
    //  {
      //  anim.SetBool("run" , false);
    //  }

    //  if (slower == null)
    //  {
    //    gameObject.GetComponent<NavMeshAgent>().speed = 2;
    //  }


    }

    void OnTriggerEnter (Collider other)
    {
      if (other.gameObject.tag == "ZSlow")
      {
        mutant.gameObject.GetComponent<NavMeshAgent>().speed = 0.8f;
        StartCoroutine(speedback());
      }
    }

    void OnTriggerExit (Collider other)
    {
      if (other.gameObject.tag == "ZSlow")
      {
        mutant.gameObject.GetComponent<NavMeshAgent>().speed = 2.6f;
      }
    }

    IEnumerator speedback ()
    {
      yield return new WaitForSeconds (9.1f);
      mutant.gameObject.GetComponent<NavMeshAgent>().speed = 2.6f;
    }
}
