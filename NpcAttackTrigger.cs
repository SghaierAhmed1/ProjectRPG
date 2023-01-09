using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAttackTrigger : MonoBehaviour
{
  //  public GameObject enemy;
    public EnemyCombat enemycombatscript;
    public bool attack = false;
    public Animator anim;
    public GameObject player;
    void Start()
    {
  //   anim = enemy.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     if (Vector3.Distance(gameObject.transform.position , player.transform.position) > 3)
     {
       anim = gameObject.GetComponent<Animator>();
       attack = false;
       anim.SetBool ("Basic Attack" , false);
     }

     if (Vector3.Distance(gameObject.transform.position , player.transform.position) <= 3.5)
     {
       anim = gameObject.GetComponent<Animator>();
       attack = true;
       anim.SetBool ("Basic Attack" , true);
     }


    }

//    void OnTriggerEnter (Collider other)
  //  {
    //  if (other.gameObject.tag == "Enemy")
    //  {
      //  anim = other.gameObject.GetComponent<Animator>();
      //  attack = true;
      //  anim.SetBool ("Basic Attack" , true);
    //  }
  //  }

  //  void OnTriggerExit (Collider other)
  //  {
  //    if (other.gameObject.tag == "Enemy")
    //  {
      //  anim = other.gameObject.GetComponent<Animator>();
      //  attack = false;
      //  anim.SetBool ("Basic Attack" , false);
    //  }
  //  }

  //  void OnTriggerExit (Collider other)
    //{
      //if (other.gameObject.tag == "Enemy")
      //{
      //  enemycombatscript.performMeleeAttack = false;
      //}
  //  }
}
