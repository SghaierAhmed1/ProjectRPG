using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargetting : MonoBehaviour
{
    public GameObject selectedHero;
    public bool heroPlayer;
    public GameObject selectedprojectile;
    RaycastHit hit;
    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(0)))
      {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit , Mathf.Infinity))
        {
          if(hit.collider.GetComponent<Targettable>() != null)
          {
            if(hit.collider.gameObject.GetComponent<Targettable>().enemyType == Targettable.EnemyType.Minion)
            {
              selectedHero.GetComponent<HeroCombat>().targetedEnemy = hit.collider.gameObject;
              //selectedprojectile.GetComponent<Projectile>().Target = hit.collider.gameObject;
            }
          }
          else if (hit.collider.gameObject.GetComponent<Targettable>() == null)
          {
            selectedHero.GetComponent<HeroCombat>().targetedEnemy = null;
            //selectedprojectile.GetComponent<Projectile>().Target = null;
          }
        }
      }
    }
}
