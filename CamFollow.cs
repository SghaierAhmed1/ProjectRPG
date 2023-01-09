using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public Transform dragon;
    private Vector3 cameraOffset;
    [Range(0.01f , 2.0f)]
    public float smoothness = 0.5f;
    void Start()
    {
        target = player;
        cameraOffset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.activeInHierarchy)
        {
          cameraOffset.y = 12;
          target = player;
          Vector3 newPos = target.position + cameraOffset;
          transform.position = Vector3.Slerp(transform.position , newPos , smoothness);
        }
        if (dragon.gameObject.activeInHierarchy)
        {
          target = dragon;
          cameraOffset.y = 15;
          Vector3 newPos = target.position + cameraOffset;
          transform.position = Vector3.Slerp(transform.position , newPos , smoothness);
        }

    }
}
