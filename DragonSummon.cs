using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSummon : MonoBehaviour
{
      public bool playeractive = true;
      public bool cantransform = true;
      public KeyCode Summon;
      public GameObject Dragon;
      public GameObject Player;
      public GameObject Cam;
      public Animator anim;
      public GameObject canv;
      public ParticleSystem Healeff;
      public ParticleSystem ManaEff;
      public ParticleSystem blood;

      void Start()
      {
       anim = Player.GetComponent<Animator>();
      }

      // Update is called once per frame
      void Update()
      {
          if (Input.GetKey(Summon) && (cantransform == true))
          {
            Cam.transform.position = new Vector3 (Cam.transform.position.x , 13 , Cam.transform.position.z);
            cantransform = false;
            if (playeractive == true)
            {
            Dragon.transform.position = Player.transform.position;
            Dragon.transform.rotation = Player.transform.rotation;
            Player.SetActive(false);
            Dragon.SetActive(true);
            canv.SetActive(false);
            playeractive = false;
            StartCoroutine(Canback());
          //  anim.SetBool("Drag" , true);
          }
          else
          {
            cantransform = false;
            Player.transform.position = Dragon.transform.position;
            Player.transform.rotation = Dragon.transform.rotation;
            Player.SetActive(true);
            Healeff.Stop();
            ManaEff.Stop();
            blood.Stop();
            Dragon.SetActive(false);
            canv.SetActive(true);
            playeractive = true;
            StartCoroutine(Canback());
          }
          }
      }

      IEnumerator Canback()
      {
        yield return new WaitForSeconds (1f);
        cantransform = true;
      }


}
