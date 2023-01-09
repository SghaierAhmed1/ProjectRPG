using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonActiveTrigger : MonoBehaviour
{
    public GameObject Boss;
    public bool k = false;
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
        Boss.SetActive(true);
        k = true;
        this.gameObject.SetActive(false);
      }
    }
}
