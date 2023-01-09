using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int healthpotion ;
    public int manapotion ;
    public GameObject healthpotionimage;
    public GameObject manapotionimage;
    public TextMeshProUGUI manaPtext;
    public TextMeshProUGUI healPthtext;
    void Start()
    {
    // healthpotion = 3;
    // manapotion = 3;
    }

    // Update is called once per frame
    void Update()
    {
      string HealthFinal = string.Format ("{0:0}" , healthpotion);
      string Manafinal = string.Format("{0:0}" , manapotion);
      manaPtext.text = Manafinal;
      healPthtext.text = HealthFinal;
      if (healthpotion > 0)
      {
        healthpotionimage.SetActive(true);
      }
      if (healthpotion < 1 )
      {
        healthpotionimage.SetActive(false);
      }
      if (manapotion > 0)
      {
        manapotionimage.SetActive(true);
      }
      if (manapotion < 1)
      {
        manapotionimage.SetActive(false);
      }
    }
}
