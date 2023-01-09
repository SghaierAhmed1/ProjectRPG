using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharMovement : MonoBehaviour
{
    private Animator animator;
    public NavMeshAgent agent;
    public float rotateSpeed = 0.1f;
    public float rotateVelocity;
    public GameObject mouse;
    private HeroCombat heroCombatScript;
    public Stats statscript;
    Abilities abscript;
    public GameObject RS;
    void Start()
    {
      statscript = GetComponent<Stats>();
     animator = GetComponent<Animator>();
     agent = gameObject.GetComponent<NavMeshAgent>();
     heroCombatScript = GetComponent<HeroCombat>();
     abscript = GetComponent<Abilities>();
    }

    // Update is called once per frame
    void Update()
    {
      //RaycastHit hit1;
      //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit1, Mathf.Infinity))
      //{
        //mouse.transform.position = new Vector3 (hit1.point.x , 1.16f , hit1.point.z - 2);
      //}
     if (statscript.health <1)
     {
       RS.SetActive(true);
     }
     if(Input.GetMouseButtonDown(1))
     {
       agent.isStopped = false;
      RaycastHit hit;
       if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
       {
         //mouse.transform.position = (hit.point);
         if ((hit.collider.tag == "Floor") || (hit.collider.tag == "ZSlow") )
         {
      //     animator.SetBool("Basic Attack" , false);
           mouse.transform.position = new Vector3 (hit.point.x , 1.16f , hit.point.z - 2);
           mouse.SetActive(true);
           StartCoroutine(MouseBack());
           agent.SetDestination(hit.point);
           heroCombatScript.targetedEnemy = null;
           agent.stoppingDistance = 1f;
           Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
           float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y , rotationToLookAt.eulerAngles.y , ref rotateVelocity , rotateSpeed *
           (Time.deltaTime * 5));
           transform.eulerAngles = new Vector3(0,rotationY,0);
         }

       }

     }
    }

    IEnumerator MouseBack()
    {
      yield return new WaitForSeconds (0.6f);
      mouse.SetActive(false);
    }
}
