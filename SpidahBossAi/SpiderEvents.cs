using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEvents : MonoBehaviour
{
    public bool isAttacking = false;
    public GameObject teeth;
    public SpidahTeethAttack teethscript;
    public GameObject Player;
    public ParticleSystem venom;
    public GameObject slider;
    public GameObject loot;
    public AudioSource walking;
    public AudioSource attackSFX;
    public AudioSource biteSFX;
    public AudioSource deathSFX;
    public ParticleSystem GauntBlood;
    public AudioSource GauntHurt;
    void Start()
    {
      venom.Stop();
     teethscript = teeth.gameObject.GetComponent<SpidahTeethAttack>();
    }

    // Update is called once per frame
    void Drop ()
    {
      if (loot != null)
          {
            loot.SetActive(true);
            loot.transform.parent = null;
            deathSFX.Play();
         }
    }
    void bite ()
    {
      biteSFX.Play();
    }
    void WalkSFX()
    {
      walking.Play();
    }
    void StopWalk ()
    {
      walking.Stop();
    }
    void Update()
    {

    }
    void slideroff ()
    {
      slider.SetActive(false);
  //    if (loot != null)
    //  {
      //  loot.SetActive(true);
      //  loot.transform.parent = null;
        deathSFX.Play();
    //  }
    }
    void venomAttack ()
    {
      venom.Play();
      attackSFX.Play();
    }
    void SpidAttack ()
    {
      if (teethscript.damage == true)
      {
        Player.gameObject.GetComponent<Stats>().health = Player.gameObject.GetComponent<Stats>().health - 2;
        GauntHurt.Play();
        GauntBlood.Play();
      }
    }

    public void attak ()
    {
      isAttacking = true;
    }

    public void noAttak()
    {
      isAttacking = false;
    }
}
