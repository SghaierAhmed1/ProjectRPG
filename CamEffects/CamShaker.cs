using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShaker : MonoBehaviour
{
    public GameObject Cam;
    public float duration =1f;
    public bool star = false;
    public AnimationCurve curve;
  //  public GameObject Shaka;
    void Start()
    {
    // StartCoroutine(SetOff());
    }

    // Update is called once per frame
    void Update()
    {
     if (star)
     {
       star = false;
       StartCoroutine(Shaking());
     }

    }

    IEnumerator Shaking ()
    {
      Vector3 startPosition = Cam.transform.position;
      float elapsedTime = 0f;

      while (elapsedTime < duration)
      {
        elapsedTime += Time.deltaTime;
        float strength = curve.Evaluate(elapsedTime/duration);
        Cam.transform.position = startPosition + Random.insideUnitSphere * strength;
        yield return null;
      }

     Cam.transform.position = startPosition;
    }

}
