using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidahTeethAttack : MonoBehaviour
{
    public bool damage = false;
    public GameObject Player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
  
    void OnTriggerEnter (Collider other)
    {
     if (other.gameObject.tag =="Player")
     {
       damage = true;
     }
    }

    void OnTriggerExit (Collider other)
    {
      if (other.gameObject.tag == "Player")
      {
        damage = false;
      }
    }
}
