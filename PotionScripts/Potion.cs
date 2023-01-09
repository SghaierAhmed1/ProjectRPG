using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject Description;
    public GameObject Player;
    public Inventory inventoryScript;
    public AudioSource PickUpSFX;
    void Start()
    {
      inventoryScript = Player.gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver ()
    {
      Description.SetActive(true);
    }

    void OnMouseExit ()
    {
      Description.SetActive(false);
    }

    void OnMouseDown ()
    {
      PickUpSFX.Play();
      gameObject.SetActive(false);
      Description.SetActive(false);
      inventoryScript.healthpotion = inventoryScript.healthpotion +1;
    }
}
