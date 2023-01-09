using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    public float rotatespeed = 1.2f;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation" , Time.time * rotatespeed);
    }
}
