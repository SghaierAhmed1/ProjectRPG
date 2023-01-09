using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZSlow : MonoBehaviour
{
  public bool k = false;
  public bool done;
  public GameObject en;


  void OnTriggerEnter (Collider other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      k = true;
      other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.8f;
      en = other.gameObject;
    }
  }

  void OnTriggerExit (Collider other)
  {
    if (other.gameObject.tag == "Enemy")
    {

      other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2f;

    }
  }

  void Update ()
  {
    if (done == true)
    {
      en.gameObject.GetComponent<NavMeshAgent>().speed = 2f;
    }
  }

}
