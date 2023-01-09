using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// THE TRIGGER SCRIPT IS ATTACHED TO THE MAIN CHARACTER ;

public class EnemyCombat : MonoBehaviour
{
    public GameObject target;
    private Stats statscript;
    public Animator anim;
    public bool melee = false;
    public float range;
    NavMeshAgent agent;

    void Start()
    {
      statscript = gameObject.GetComponent<Stats>();
      anim = gameObject.GetComponent<Animator>();
      agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {


}

}
