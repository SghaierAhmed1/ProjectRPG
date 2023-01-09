using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossStateMachine : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent enemy;
    public Transform player;
    public GameObject Gunt;
    public Stats statScript;
    float motionSmoothTime = .1f;
    public GameObject DragonSlider;
    public float rotatespeed = 2;
    public float rotatevelocity;
    public DragonEvents eventsScript;
    public GameObject Eyes;
    public InSight seeScript;
    public AudioSource WorldMusic;
    public AudioSource BossMusic;
    IEnumerator Start ()
    {
      WorldMusic.Pause();
      BossMusic.Play();
      seeScript = Eyes.GetComponent<InSight>();
      eventsScript = gameObject.GetComponent<DragonEvents>();
      DragonSlider.SetActive(true);
      statScript = gameObject.GetComponent<Stats>();
      anim = gameObject.GetComponent<Animator>();

      while (true)
      {
      //  transform.LookAt(player);
        //Quaternion rotation = Quaternion.Euler(0,30,0);

        yield return new WaitForSeconds (2.8f);
    //    var rotation = Quaternion.LookRotation(player.position - transform.position);
      //  transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
        anim.SetInteger ("AttackIndex" , Random.Range(0,4));


    //   transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);
      //  yield return new WaitForSeconds (0.5f);
        anim.SetTrigger("Attack");
        anim.SetBool("CanAttack" , false);
      anim.SetFloat("Speed" , 0);

      }
    }

    public void Update ()
    {
      if ((seeScript.see == false) && (anim.GetBool("CanAttack") == false) && (eventsScript.isAttacking == false))
      {
        anim.SetFloat("Speed" , 1);
        var rotation = Quaternion.LookRotation(player.position - transform.position);
       transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
      }
      if (statScript.health<0.5f)
      {
        this.GetComponent<BossStateMachine>().enabled = false;
        this.GetComponent<BossStateMachine>().enabled = false;
    //    this.GetComponent<NavMeshAgent>().SetActive(false);
        DragonSlider.SetActive(false);
      }
        if (anim.GetBool("CanAttack") == true)
        {
          anim.SetFloat("Speed" , 0);
        }
        if((Vector3.Distance(gameObject.transform.position, Gunt.transform.position) <= 7) && (eventsScript.isAttacking == false) && (seeScript.see == true) )
        {
        //  var rotation = Quaternion.LookRotation(player.position - transform.position);
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
          anim.SetBool("CanAttack" , true);
          anim.SetFloat("Speed" , 0);
        //  transform.LookAt(player);
      //    Quaternion rotation = Quaternion.Euler(0,30,0);
        }
        else
        if ((Vector3.Distance(gameObject.transform.position, Gunt.transform.position) > 7) && (anim.GetBool("CanAttack") == false) &&  (eventsScript.isAttacking == false))
        {
      //    anim.SetBool("CanAttack" , false);
          float speed1 = enemy.velocity.magnitude / enemy.speed;
          anim.SetFloat("Speed" , speed1 , motionSmoothTime , Time.deltaTime);
          if ((statScript.health>0)  && (anim.GetBool("CanAttack") == false))
          {

            enemy.SetDestination(player.position);
          //  transform.LookAt(player);
            //Quaternion rotation = Quaternion.Euler(0,30,0);

            var rotation = Quaternion.LookRotation(player.position - transform.position);
           transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);

          }
          else
          if (statScript.health<0.5f)
          {
            BossMusic.Stop();
          //  WorldMusic.Play();
            this.GetComponent<BossStateMachine>().enabled = false;
            this.GetComponent<DragonEvents>().enabled = false;
            DragonSlider.SetActive(false);
            StartCoroutine (MusicBack());
          }
        }
    }
    void OnTriggerEnter (Collider other)
    {
      if (other.gameObject.tag == "ZSlow")
      {
        gameObject.GetComponent<NavMeshAgent>().speed = 1f;
       StartCoroutine(speedback());
      }
    }
    void OnTriggerExit (Collider other)
    {
      if (other.gameObject.tag == "ZSlow")
      {
        gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;
      }
    }
    IEnumerator speedback ()
    {
      yield return new WaitForSeconds (9.1f);
      gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;
    }

    IEnumerator MusicBack ()
    {
      yield return new WaitForSeconds (15f);
      WorldMusic.Play();
    }
}
