using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUI : MonoBehaviour {

    private void Update()
    {
        if(Input.GetKey("escape"))
        {
            Debug.Log("Exit");
            Application.Quit();
            
        }
    }
}
