using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFire : MonoBehaviour
{
    public ParticleSystem part;
    public float power;
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision (GameObject other)
    {
      if (other.gameObject.tag == "Player")
      {
      //  Debug.Log("Tnekna");
        other.gameObject.GetComponent<Stats>().health = (other.gameObject.GetComponent<Stats>().health) - power;
      }
    }
}
