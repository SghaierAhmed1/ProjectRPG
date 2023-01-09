using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stats : MonoBehaviour
{
    public float maxhealth;
    public float health;
    public float maxMana;
    public float mana;
    public float AD;
    public float AP;
    public float attackspeed;
    public float attackTime;
    public float manaregenspeed = 2;
    HeroCombat heroCombatScript;
    private Animator anim;
    public int TargetsNumber;
    void Start()
    {
        TargetsNumber = 0;
        anim = gameObject.GetComponent<Animator>();
        heroCombatScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroCombat>();
    }

    // Update is called once per frame

   void Update()
   {
     if (mana < maxMana)
     {
       mana+=Time.deltaTime*manaregenspeed;
     }
   }

    void LateUpdate()
    {
      if (health <= 0.5f)
      {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        anim.SetBool("Dead" , true);
      //  heroCombatScript.targetedEnemy = null;
        heroCombatScript.performMeleeAttack = false;
        this.gameObject.GetComponent<Targettable>().enabled = false;
      }
    }
}
