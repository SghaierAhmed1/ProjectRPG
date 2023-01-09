using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour
{
    public float damage;
    public GameObject target;
    public bool targetSet;
    public string targetType;
    public float velocity = 5;
    public bool stopProjectile;
    public GameObject selectedHero;
  //  public GameObject player;
  //public AudioSource ProjSoundFX;



    void Start ()
    {
  //    ProjSoundFX.Play

        selectedHero = GameObject.FindGameObjectWithTag("Player");
        target = selectedHero.GetComponent<HeroCombat>().targetedEnemy;
    }
    void Update()
    {
      if (target == null)
      {
        target = selectedHero.GetComponent<HeroCombat>().targetedEnemy;
    //    Destroy(gameObject);
      }
      if (target)
      {
    //    target = selectedHero.GetComponent<HeroCombat>().targetedEnemy;
        transform.position = Vector3.MoveTowards(transform.position , target.transform.position, velocity * Time.deltaTime);
        if (!stopProjectile)
        {
          if(Vector3.Distance(transform.position , target.transform.position ) <0.5f )
          {
            if( targetType == "Minion")
            {
              target.GetComponent<Stats>().health -= damage;
              stopProjectile = true;
              Destroy(gameObject);
            }
          }
        }
      }
    }
}
