using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragMovement : MonoBehaviour
{
  public NavMeshAgent enemy;
  public Transform player;
  public Stats statScript;
  Animator anim;
  float motionSmoothTime = .1f;
  public GameObject DragonSlider;
  public DragonEvents DragEventScript;



    void Start()
    {
      DragEventScript = gameObject.GetComponent<DragonEvents>();
      DragonSlider.SetActive(true);
      statScript = gameObject.GetComponent<Stats>();
      anim = gameObject.GetComponent<Animator>();
  //    slowscript = gameObject.GetComponent<ZSlow>();
    //  destscript = gameObject.GetComponent<ZDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
      float speed1 = enemy.velocity.magnitude / enemy.speed;
      anim.SetFloat("Speed" , speed1 , motionSmoothTime , Time.deltaTime);
      if ((statScript.health>0) && (DragEventScript.follow == true))
      {

        enemy.SetDestination(player.position);
        transform.LookAt(player);
        Quaternion rotation = Quaternion.Euler(0,30,0);
      }
      else
      if (statScript.health<=0)
      {
        DragonSlider.SetActive(false);
      }
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
    gameObject.GetComponent<NavMeshAgent>().speed = 2f;
  }
}

IEnumerator speedback ()
{
  yield return new WaitForSeconds (9.1f);
  gameObject.GetComponent<NavMeshAgent>().speed = 2f;
}
}
