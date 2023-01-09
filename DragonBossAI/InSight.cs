using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSight : MonoBehaviour
{
    public bool see = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter (Collider other)
    {
      if (other.gameObject.tag == "Player")
      {
        see = true;
      }
    }

    void OnTriggerExit (Collider other)
    {
      if (other.gameObject.tag == "Player")
      {
        see = false;
      }
    }
}
