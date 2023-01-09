using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject Enemy;
    public bool k = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggetEnter(Collider other)
        {
          if (other.gameObject.tag == "Player")
          {
          Enemy.SetActive(true);
          k = true;
        }
        }
    }
}
