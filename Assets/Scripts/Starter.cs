using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public string sceneOne, sceneTwo;
    float gameChooseCounter;
    bool counterDirection;
    public float GameChooseCounter => this.gameChooseCounter;
    void Awake(){
        Cursor.visible = false;
        this.counterDirection = true;
        this.gameChooseCounter = 0f;
    }
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.F12)){
            SceneChanger.instance.ChangeSceneToWithoutEndCapturing("Game");
        }*/

        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.F12)){
            this.Count();
        }
        if(Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.F12)){
            this.StartGame();
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            SceneChanger.instance.ChangeSceneTo(this.sceneTwo);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            SceneChanger.instance.ChangeSceneTo(this.sceneOne);
            
        }
    }

    void Count(){
        if(this.counterDirection){
            this.gameChooseCounter += Time.deltaTime;
            if(this.gameChooseCounter >= 1f)
                this.counterDirection = false;
        }else{
            this.gameChooseCounter -= Time.deltaTime;
            if(this.gameChooseCounter <= 0f)
                this.counterDirection = true;

        }
    }

    void StartGame(){
        if(this.gameChooseCounter > .5f){
            SceneChanger.instance.ChangeSceneTo(this.sceneOne);
        }else{
            SceneChanger.instance.ChangeSceneTo(this.sceneTwo);

        }
    }
}
