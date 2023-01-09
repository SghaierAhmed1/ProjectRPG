using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Abilities : MonoBehaviour
{
    public ParticleSystem blood;
    private HeroCombat combatscript;
    private Stats statsScript;
    [Header("Ability1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;
    public Animator anim;
    public GameObject c;
    public float QcastTime = 2;
    public GameObject Fireball;
    public float manacost = 30;

    [Header("Ability2")]
    public Image abilityImage2;
    public float cooldown2 = 30;
    bool isCooldown2 = false;
    public KeyCode ability2;
    public float manacost2 = 20;
    public GameObject van;


    [Header("Ability3")]
    public Image abilityImage3;
    public float cooldown3 = 15;
    bool isCooldown3 = false;
    public KeyCode ability3;
    public bool flashing = false;
    public float manacost3 = 17;
    public float distance;

    [Header("Ability4")]
    public Image abilityImage4;
    public float cooldown4 = 15;
    bool isCooldown4 = false;
    public KeyCode ability4;
  //  public bool flashing = false;
    public float manacost4 = 17;
    public GameObject Rain;
  //  public float distance;
    [Header("Heal")]
    public Inventory InventoryScript;
    public ParticleSystem healeffect;
    public KeyCode Heal;
    public AudioSource HealSoundEffect;
    public bool canheal = true;

    [Header("ManaReg")]
  //  public Inventory InventoryScript;
  public ParticleSystem manaeffect;
    public KeyCode Regen;
    public bool canregen = true;
    public AudioSource manaSFX;

    void Start()
    {
      blood.Stop();
      manaeffect.Stop();
      healeffect.Stop();
     anim = c.GetComponent<Animator>();
     abilityImage1.fillAmount = 0;
     abilityImage2.fillAmount = 0;
     abilityImage3.fillAmount = 0;
     abilityImage4.fillAmount = 0;
     combatscript = GetComponent<HeroCombat>();
     statsScript = GetComponent<Stats>();
     InventoryScript = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

    Ability1();
    Ability2();
    Ability3();
    Ability4();
    Healing();
    ManaRegen();
    }

    void ManaRegen ()
    {
      {
        if ((Input.GetKey(Regen)) && ((InventoryScript.manapotion)>0) && (canregen == true))
        {
          manaeffect.Play();
          manaSFX.Play();
          InventoryScript.manapotion = InventoryScript.manapotion - 1;
          canregen = false;
          StartCoroutine(regenback());

          if ((statsScript.mana)<60)
          {
            statsScript.mana = (statsScript.mana) + 40;
          }
          else
          if ((statsScript.mana) >= 60)
          {
            statsScript.mana = 100;
          }
        }
      }
    }

    void Healing ()
    {
      if ((Input.GetKey(Heal)) && ((InventoryScript.healthpotion)>0) && (canheal == true))
      {
      //  healeffect.transform.position = transform.position;
        healeffect.Play();
        HealSoundEffect.Play();
        InventoryScript.healthpotion = InventoryScript.healthpotion - 1;
        canheal = false;
        StartCoroutine (healback());
        if ((statsScript.health)<60)
        {
          statsScript.health = (statsScript.health) + 40;
        }
        else
        if ((statsScript.health) >= 60)
        {
          statsScript.health = 100;
        }
      }
    }

    void AbilityFire ()
    {
      Fireball.SetActive(true);
    }
    void Ability1()
    {
      if (Input.GetKey(ability1) && (isCooldown == false) && (combatscript.targetedEnemy != null ) && (manacost <= statsScript.mana))
      {
        anim.SetBool("QCastable" , true);
        StartCoroutine("Qback");
      }
      if(Events.fired == true)
      {

        isCooldown = true;
        abilityImage1.fillAmount = 1;
        Events.fired = false;
        statsScript.mana -= manacost;

      }
      if (isCooldown)
      {

        abilityImage1.fillAmount -= 1 / cooldown1 *Time.deltaTime;
        if (abilityImage1.fillAmount <= 0 )
        {
          abilityImage1.fillAmount = 0;
          isCooldown = false;

        }
      }
    }

    void Ability2()
    {
      if (Input.GetKey(ability2) && (isCooldown2 == false) && (manacost2 <= statsScript.mana) )
      {

        RaycastHit hit ;
         if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
         {
        combatscript.ZSpawnPoint.transform.position = new Vector3 (hit.point.x , 0 , hit.point.z);
        anim.SetBool("ZCastable" , true);
        StartCoroutine("Zback");
        isCooldown2 = true;
        abilityImage2.fillAmount = 1;
        statsScript.mana -= manacost2;

      }
      }
      if (isCooldown2)
      {
        abilityImage2.fillAmount -= 1 / cooldown2 *Time.deltaTime;
        if (abilityImage2.fillAmount <= 0 )
        {
          abilityImage2.fillAmount = 0;
          isCooldown2 = false;
        }
      }
    }

    void Ability3()
    {
      if (Input.GetKey(ability3) && (isCooldown3 == false)  && (manacost3 <= statsScript.mana))
      {
    //    van.SetActive(true);
        flashing = true;
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        gameObject.GetComponent<HeroCombat>().targetedEnemy = null;
        RaycastHit hit ;
         if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
         {
           gameObject.transform.position = new Vector3 (hit.point.x , 0 , hit.point.z);
           transform.LookAt(hit.point);
          //  transform.rotation = Quaternion.LookRotation(hit.transform.rotation);


      //  StartCoroutine("Eback");
        isCooldown3 = true;
        abilityImage3.fillAmount = 1;
        statsScript.mana -= manacost3;
      //  StartCoroutine(Vanback());
      }

      }
      if (isCooldown3)
      {
        abilityImage3.fillAmount -= 1 / cooldown3 *Time.deltaTime;
        if (abilityImage3.fillAmount <= 0 )
        {
          abilityImage3.fillAmount = 0;
          isCooldown3 = false;
        }
      }
    }

    void Ability4()
    {
      if (Input.GetKey(ability4) && (isCooldown4 == false) && (manacost4 <= statsScript.mana) )
      {
        StartCoroutine (Rainback());
        RaycastHit hit ;
         if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
         {
        Rain.gameObject.transform.position = new Vector3 (hit.point.x , hit.point.y , hit.point.z);
        Rain.SetActive(true);
        isCooldown4 = true;
        abilityImage4.fillAmount = 1;
        statsScript.mana -= manacost4;
      }
      }
      if (isCooldown4)
      {
        abilityImage4.fillAmount -= 1 / cooldown4 *Time.deltaTime;
        if (abilityImage4.fillAmount <= 0 )
        {
          abilityImage4.fillAmount = 0;
          isCooldown4 = false;
        }
      }
    }

    IEnumerator Zback()
    {
      yield return new WaitForSeconds (0.8f);
      anim.SetBool("ZCastable" , false);
    }

    IEnumerator Qback()
    {
      yield return new WaitForSeconds (0.1f);
      anim.SetBool("QCastable" , false);
      yield return new WaitForSeconds(QcastTime);
      anim.SetBool("QReady" , true);
      //yield return new WaitForSeconds(0.6f);
      yield return new WaitForSeconds(0.01f);
      anim.SetBool("QReady" , false);

    }

    IEnumerator Rainback()
    {
      yield return new WaitForSeconds (6f);
      Rain.SetActive(false);
    }

    IEnumerator healback()
    {
      yield return new WaitForSeconds (1f);
      canheal = true;
    }
    IEnumerator regenback()
    {
      yield return new WaitForSeconds (1f);
      canregen = true;
    }

//    IEnumerator Vanback()
  //  {
    //  yield return new WaitForSeconds(0.4f);
    //  van.SetActive(false);
  //  }

}
