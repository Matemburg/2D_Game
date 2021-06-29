using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSetter : MonoBehaviour
{
public Material mat1;



void Start()
    {
        RenderSettings.skybox = mat1;
        RenderSettings.skybox.SetColor("_Tint", Color.gray);
    }


}
