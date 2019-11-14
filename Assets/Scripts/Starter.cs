using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    void Start(){
        Cursor.visible = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.F12)){
            SceneChanger.instance.ChangeSceneToWithoutEndCapturing("Game");
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
