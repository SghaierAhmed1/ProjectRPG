using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonJumCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public Stats DragonStats;
    public GameObject dragon;
    void Start()
    {
     DragonStats = dragon.gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
     dragon.gameObject.GetComponent<Stats>().health = DragonStats.health;
    }
}
