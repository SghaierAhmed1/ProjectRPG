using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvents : MonoBehaviour
{
  public NpcAttackTrigger npcattackscript;
  public GameObject Enemy;
  public Stats statscript;
  public GameObject player;
  public GameObject Cam;
  public CamShaker shakeScript;
  public ParticleSystem muzzle;
  public AudioSource hurt;
  public GameObject loot;
  public AudioSource impact;
  public AudioSource AttackSFX;
  public AudioSource DeathSFX;
  public AudioSource Sounds;
  public bool Attacking = false;
    void Start()
    {
      shakeScript = Cam.gameObject.GetComponent<CamShaker>();
      npcattackscript = gameObject.GetComponent<NpcAttackTrigger>();
    }

           public void canmove ()
           {
             Attacking = false;
           }

           public void cantmove ()
           {
             Attacking = true;
           }


            public void LootActive ()
            {
              if (loot != null)
              {
                loot.SetActive(true);
                loot.transform.parent = null;
              }
            }
            public void deadSounds ()
            {
              DeathSFX.Play();
              Sounds.Stop();
            }
            public void attackingsfx ()
            {
              AttackSFX.Play();
            }
        public void HealthChip ()
        {
        //  if (npcattackscript.attack == true)
        //  {
        hurt.Play();
            muzzle.Play();
            impact.Play();
            player.gameObject.GetComponent<Stats>().health -= Enemy.gameObject.GetComponent<Stats>().AD;
            player.gameObject.GetComponent<Animation>().Play("HeadHit");
            shakeScript.star = true;
        //  }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
