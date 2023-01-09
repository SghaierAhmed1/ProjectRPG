using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEvents : MonoBehaviour
{
    public bool follow = false;
    public float attackRange;
    public GameObject DragBar;
    public GameObject Flames;
    public GameObject Flame2;
    public ParticleSystem Fire1;
    public ParticleSystem Fire2;
    public AudioSource FlameSFX;
    public bool isAttacking = false;
    public Transform player;
    public DragonHeadCollision Draghead;
    public GameObject Gunt;
    public GameObject head;
    public BoxCollider collo;
    public GameObject cam;
    public CamShaker shakingScript;
      public ParticleSystem muzzle;
      public AudioSource GuntHurt;
      public AudioSource wingforward;
       public AudioSource flappingWings;
       public AudioSource jumgro;
       public AudioSource basegrowl;
       public AudioSource dying;
       public AudioSource BossMusic;
      // public AudioSource flameSound;
    void Start()
    {
      shakingScript = cam.gameObject.GetComponent<CamShaker>();
      collo = GetComponent<BoxCollider>();
       Fire1.Stop();
       Fire2.Stop();
       Draghead = head.gameObject.GetComponent<DragonHeadCollision>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DeathMoanSFX()
    {
      BossMusic.Stop();
      dying.Play();
    }
    void BasicGrowlSFX()
    {
      basegrowl.Play();
    }
    void jumpgrowl ()
    {
      jumgro.Play();
    }
    void Flapping ()
    {
      flappingWings.Play();
    }
    void ForwardSFX ()
    {
    //  jumgro.Play();
      wingforward.Play();
    }
    void BoxForward ()
    {
      collo.center = collo.center + new Vector3 (0,0,5);
    }

    void BoxBack ()
    {
      collo.center = collo.center - new Vector3 (0,0,5);
    }



    void HeadOnn ()
    {
      head.SetActive(true);
    }

    void HeadOff ()
    {
      head.SetActive(false);
    }

    void HeadAttack ()
    {
      if (Draghead.hit == true)
      {
        GuntHurt.Play();
        muzzle.Play();
        Gunt.gameObject.GetComponent<Stats>().health = Gunt.gameObject.GetComponent<Stats>().health - 13;
        shakingScript.star = true;
      }
    }

    public void canTurn ()
    {
      isAttacking = false;
    }

    public void CanNotTurn ()
    {
      isAttacking = true;
    }

    public void DragOff ()
    {
      DragBar.SetActive(false);
    }

    public void FlameOnn ()
    {
      Fire1.Play();
      FlameSFX.Play();
    }

    public void FlameOff()
    {
      Fire1.Stop();
      FlameSFX.Stop();
    }

    public void Flame2On()
    {
      Fire2.Play();
      FlameSFX.Play();
    }

    public void Flame2OFF ()
    {
      Fire2.Stop();
      FlameSFX.Stop();
    }

    public void turn ()
    {
      var rotation = Quaternion.LookRotation(player.position - transform.position);
      transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
    }
}
