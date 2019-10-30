using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            SceneChanger.instance.ChangeSceneToWithoutEndCapturing("Game");
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
