using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperEvents : MonoBehaviour
{
    public bool isAttacking = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Attack ()
    {
      isAttacking = true;
    }

    void StopAttack ()
    {
      isAttacking = false;
      Debug.Log("Stopping");
    }
}
