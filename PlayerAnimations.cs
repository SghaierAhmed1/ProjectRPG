using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimations : MonoBehaviour
{
    NavMeshAgent agent;
    public Animator anim;
    float motionSmoothTime = .1f;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed1 = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speed" , speed1 , motionSmoothTime , Time.deltaTime);
    }
}
