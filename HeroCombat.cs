using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCombat : MonoBehaviour
{
    public enum HeroAttackType { Melee, Ranged };
    public HeroAttackType heroAttackType;

    public GameObject targetedEnemy;
    public float attackRange;
    public float rotateSpeedForAttack;

    private CharMovement moveScript;
    private Stats statsScript;
    private Animator anim;

    public bool basicAtkIdle = false;
    public bool isHeroAlive;
    public bool performMeleeAttack = true;

    [Header("Ranged Varialbes")]
    public bool performRangedAttack = true;
    public GameObject projPrefab;
    public GameObject projPrefab2;
    public Transform projSpawnPoint;
    public Transform ZSpawnPoint;
    public GameObject Zprefab;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<CharMovement>();
        statsScript = GetComponent<Stats>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(targetedEnemy != null)
        {
            if(Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange)
            {
                moveScript.agent.SetDestination(targetedEnemy.transform.position);
                moveScript.agent.stoppingDistance = attackRange;
            }
            else
            {
                //MELEE CHARACTRER
                if(heroAttackType == HeroAttackType.Melee)
                {
                    //ROTATION
                    Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref moveScript.rotateVelocity,
                        rotateSpeedForAttack * (Time.deltaTime * 5));

                //    transform.eulerAngles = new Vector3(0, rotationY, 0);
                    transform.LookAt(targetedEnemy.transform.position);

                    moveScript.agent.SetDestination(transform.position);

                    if (performMeleeAttack)
                    {
                      //  Debug.Log("Attack The Minion");

                      //  Start Coroutine To Attack
                        StartCoroutine(MeleeAttackInterval());
                    }
                }

                //Ranged CHARACTRER
                if(heroAttackType == HeroAttackType.Ranged)
                {
                    //ROTATION
                    Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref moveScript.rotateVelocity,
                        rotateSpeedForAttack * (Time.deltaTime * 5));

                //    transform.eulerAngles = new Vector3(0, rotationY, 0);
                    transform.LookAt(targetedEnemy.transform.position);

                    moveScript.agent.SetDestination(transform.position);

                    if (performRangedAttack)
                    {
                      //  Debug.Log("Attack The Minion");

                      //  Start Coroutine To Attack
                        StartCoroutine(RangedAttackInterval());
                    }
                }

              }
            }
          }



          IEnumerator MeleeAttackInterval ()
          {
            performMeleeAttack = false;
            anim.SetBool ("Basic Attack" , true);
            yield return new WaitForSeconds (statsScript.attackTime / ((100+statsScript.attackTime) *0.01f ));

            if (targetedEnemy == null)
            {
              anim.SetBool("Basic Attack" , false);
              performMeleeAttack = true;
            }
          }

          IEnumerator RangedAttackInterval ()
          {
            performRangedAttack = false;
            anim.SetBool ("Basic Attack" , true);
            yield return new WaitForSeconds (statsScript.attackTime / ((100+statsScript.attackTime) *0.01f ));

            if (targetedEnemy == null)
            {
              anim.SetBool("Basic Attack" , false);
              performRangedAttack = true;
            }
          }

          public void MelleAttack ()
          {
            if (targetedEnemy !=null)
            {
            if (targetedEnemy.GetComponent<Targettable>().enemyType == Targettable.EnemyType.Minion)
            {
              targetedEnemy.GetComponent<Stats>().health -= statsScript.AD;
            }
          }
          performMeleeAttack = true;
        }

        public void RangedAttack ()
        {
          if (targetedEnemy != null)
          {
          if (targetedEnemy.GetComponent<Targettable>().enemyType == Targettable.EnemyType.Minion)
          {
            SpawnRangedProj("Minion" , targetedEnemy);
          }
        }
        performRangedAttack = true;
      }

      void SpawnRangedProj ( string typeOfEnemy , GameObject targetedEnemyObj )
      {
         float dmg = statsScript.AD;

         Instantiate(projPrefab, projSpawnPoint.transform.position , Quaternion.identity);
         if (typeOfEnemy == "Minion")
         {
           projPrefab.GetComponent<RangedProjectile>().targetSet = true;
           projPrefab.GetComponent<RangedProjectile>().targetType = typeOfEnemy;
           projPrefab.GetComponent<RangedProjectile>().target = targetedEnemyObj;
           projPrefab.GetComponent<RangedProjectile>().targetSet = true;
         }
      }

      public void QAttack ()
      {
        if (targetedEnemy != null)
        {
        if (targetedEnemy.GetComponent<Targettable>().enemyType == Targettable.EnemyType.Minion)
        {
          SpawnRangedProj2("Minion" , targetedEnemy);
        }
      }
      performRangedAttack = true;
    }

    void SpawnRangedProj2 ( string typeOfEnemy , GameObject targetedEnemyObj )
    {
       float dmg = statsScript.AD;

       Instantiate(projPrefab2, projSpawnPoint.transform.position , Quaternion.identity);
       if (typeOfEnemy == "Minion")
       {
         projPrefab2.GetComponent<RangedProjectile>().targetSet = true;
         projPrefab2.GetComponent<RangedProjectile>().targetType = typeOfEnemy;
    //     projPrefab2.GetComponent<RangedProjectile>().target = targetedEnemyObj;
            projPrefab2.GetComponent<RangedProjectile>().targetSet = true;

       }
    }

    void spawnZ ()
    {
      Instantiate (Zprefab , ZSpawnPoint.transform.position , Quaternion.identity);
    }

}
