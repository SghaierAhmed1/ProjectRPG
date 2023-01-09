using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthSlide : MonoBehaviour
{

    //public int health;
    Slider playerslider;
    Stats statsScript;
    public TextMeshProUGUI healthtext;
  //  public TextMeshProUGUI castTime;
  //  float timing = 2f;
    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        playerslider = GetComponent<Slider>();
        playerslider.maxValue = statsScript.maxhealth;
        statsScript.health = statsScript.maxhealth;
        //playerslider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
      float current = statsScript.health;
      float max = statsScript.maxhealth;


      string manaT = string.Format ("{0:0} / 100" , current , max);
      healthtext.text = manaT;
      playerslider.value = statsScript.health ;


    }
}
