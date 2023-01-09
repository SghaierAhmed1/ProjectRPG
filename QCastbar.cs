using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QCastbar : MonoBehaviour
{
    public Slider slid;
    public float gametime;
    private bool stoptimer;
    public float time;
    void Start()
    {
        stoptimer = false;
        slid.maxValue = gametime +Time.time + 2;
        slid.value = gametime +Time.time;
        time = gametime + Time.time;

    }

    void Awake ()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (time >= slid.maxValue)
        {
          stoptimer = true;
        }
        if (stoptimer == false)
        {
          slid.value = time;
          time = gametime + Time.time;
        }
    }
}
