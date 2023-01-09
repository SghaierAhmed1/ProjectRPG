using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    public GameObject Met1;
    public GameObject Met2;
    public GameObject Met3;
    public GameObject Met4;
    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine (Shower());
    }

    // Update is called once per frame
    void Update()
    {
    // StartCoroutine (Shower());
    }

    public void MeteorOff ()
    {
      Met1.SetActive(false);
      Met2.SetActive(false);
      Met3.SetActive(false);
      Met4.SetActive(false);
    //  this.GetComponent(Meteors).enabled(false);
    }

    IEnumerator Shower ()
    {
      Met1.SetActive(true);
      yield return new WaitForSeconds (0.3f);
      Met2.SetActive(true);
      yield return new WaitForSeconds (0.3f);
      Met3.SetActive(true);
      yield return new WaitForSeconds (0.3f);
      Met4.SetActive(true);
      yield return new WaitForSeconds (3f);
      MeteorOff();

    }
}
