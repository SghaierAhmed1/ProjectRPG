using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManaSlider : MonoBehaviour
{

    //public int health;
    Slider manaSlider;
    Stats statsScript;
    public TextMeshProUGUI manatext;
    public TextMeshProUGUI castTime;
    float timing = 2f;
    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        manaSlider = GetComponent<Slider>();
        manaSlider.maxValue = statsScript.maxMana;
        statsScript.mana = statsScript.maxMana;
        //playerslider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
      float current = statsScript.mana;
      float max = statsScript.maxMana;

    
      string manaT = string.Format ("{0:0} / 100" , current , max);
      manatext.text = manaT;
      manaSlider.value = statsScript.mana ;


    }
}
