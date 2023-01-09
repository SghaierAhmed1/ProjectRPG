using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAuraTest : MonoBehaviour
{
    public bool k;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter (Collider col)
    {
      if (col.gameObject.tag == "Enemy")
      {
        k = true;
      }
    }
}
