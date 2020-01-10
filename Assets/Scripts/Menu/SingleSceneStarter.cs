using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSceneStarter : MonoBehaviour
{
    public string sceneName;
    public float time;


    void Awake(){
        this.time = (float)PlayerPrefsManager.GetStartDuration();
    }
    void Update(){
        this.time -= Time.deltaTime;
        if(this.time <= 0){
            SceneChanger.instance.ChangeSceneTo(this.sceneName);
        }
    }
}
