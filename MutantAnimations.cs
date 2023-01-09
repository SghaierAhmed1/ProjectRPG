using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MutantAnimations : MonoBehaviour
{
    NavMeshAgent agent;
    public Animator anim;
    float motionSmoothTime = .1f;
    public Stats statScript;
    public EnemyFollow followscript;
    public GameObject MutCanva;
    void Start()
    {
        statScript = gameObject.GetComponent<Stats>();
        followscript = gameObject.GetComponent<EnemyFollow>();
        anim = gameObject.GetComponent<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed1 = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed" , speed1 , motionSmoothTime , Time.deltaTime);
        if (statScript.health <= 0.5f)
        {
          followscript.enabled =false;
          MutCanva.SetActive(false);
        }
    }
}
