using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHeadCollision : MonoBehaviour
{
   public bool hit = false;
   public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DragAttack ()
    {
      if (hit == true)
      {
        Player.gameObject.GetComponent<Stats>().health = Player.gameObject.GetComponent<Stats>().health - 20;
      }
    }

    void OnTriggerEnter (Collider other)
    {
      if (other.gameObject.tag == "Player")
      {
        Debug.Log("Bourass");
        hit = true;
      }
    }

    void  OnTriggerExit (Collider other)
    {
      if (other.gameObject.tag == "Player")
      {
        hit = false;
      }
    }
}
