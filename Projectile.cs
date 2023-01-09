using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject proj;
    private HeroCombat combat;
    public GameObject Target;

    // Update is called once per frame
    void Start ()
    {

    }
    void Update()
    {
        transform.Translate (Target.transform.position*speed*Time.deltaTime);
        StartCoroutine("Dest");
    }

    IEnumerator Dest()
    {
      yield return new WaitForSeconds(5f);
      proj.SetActive(false);

    }
}
