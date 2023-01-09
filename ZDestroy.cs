using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    ZSlow slowscript ;
  //  EnemyFollow followcs;
    void Start()
    {
      StartCoroutine(Dest());
  //    slowscript = gameObject.GetComponent<ZSlow>();
    //  followcs = GameObject.FindGameObjectWithTag("Enemy").gameObject.GetComponent<EnemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Dest()
    {
      yield return new WaitForSeconds (9f);
    //  followcs.unslow = true;
      Destroy(gameObject);
    }
}
