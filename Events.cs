using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public GameObject FBall;
    public GameObject FireSound;


    public static bool fired;
    public bool f1 = fired;
    public static bool canhit;
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public Animator anim;
    public GameObject QSlide;
    public float gametime;
    private bool stoptimer;
    public Slider slid;
    public GameObject QCaster;
    public NpcAttackTrigger npcattackscript;
  //  public GameObject Enemy;
    public Stats statscript;
    HeroCombat combatscript;
    public AudioSource AutoAttackSFX;
    public AudioSource FireballThrow;
  //  public ParticleSystem DecoyFireBall;
  //  public GameObject loot;


        void Start()
        {
      //   DecoyFireBall.Stop();
         agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
         anim = gameObject.GetComponent<Animator>();
         combatscript = gameObject.GetComponent<HeroCombat>();
    //     npcattackscript = Enemy.gameObject.GetComponent<NpcAttackTrigger>();
        }


  //  public void HealthChip ()
  //  {
    //  if (npcattackscript.attack == true)
    //  {
      //  player.gameObject.GetComponent<Stats>().health -= Enemy.gameObject.GetComponent<Stats>().AD;
    //  }
  //  }
  //  public void DecoyOn ()
    //{
    //  DecoyFireBall.Play();
    //}
    //public void DecoyOff()
    //{
    //  DecoyFireBall.Stop();
  //  }
  public void AutoSFX ()
  {
    AutoAttackSFX.Play();
  }

  public void FireSFX ()
  {
    FireballThrow.Play();
  }
    public void appear ()
    {
      FBall.SetActive(true);
    }

    public void disappear ()

    {
      FBall.SetActive(false);
    }

    public void FirePlay ()
    {
      FireSound.SetActive(true);
    }

    public void FireStop()
    {
      FireSound.SetActive(false);
    }

    public void Throw ()
    {
      FBall.GetComponent<Projectile>().enabled = true;
    }

    public void fire ()
    {
      fired = true;
    }

    public void Can ()
    {
      canhit = true;
    }

    public void cant ()
    {
      canhit = false;
    }

    public void canwalk ()
    {
      player.GetComponent<CharMovement>().enabled = true;
    }

    public void cantwalk()
    {
      player.GetComponent<CharMovement>().enabled = false;
    }

    public void  noauto ()
    {
      anim.SetBool("Basic Attack" , false);
    }

    public void yesauto ()
    {
      anim.SetBool("Basic Attack" , true);
    }
    public void SetQSlide ()
    {
      QCaster.SetActive(true);
    }


    public void HideQSlide()
    {
      QCaster.SetActive(false);
    }
    public void detarget ()
    {
      combatscript.targetedEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
