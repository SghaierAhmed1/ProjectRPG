using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSlider : MonoBehaviour
{
    Slider enemySlider;
    //public int health;
    Stats statsScript;
    public GameObject me;
    void Start()
    {
        statsScript = me.gameObject.GetComponent<Stats>();
        enemySlider = GetComponent<Slider>();
        enemySlider.maxValue = statsScript.maxhealth;
        statsScript.health = statsScript.maxhealth;
        //playerslider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
      enemySlider.value = statsScript.health;
    }
}
