using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public static SceneChanger instance = null;

    public string lastScene = "Menu_Main";
    //public Capturing myCapturer;

	void Awake(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }else{
            if(instance != this){
                Destroy(this.gameObject);
            }
        }   
	}
    public void ChangeSceneTo(string sceneName)
    {
        this.lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

	void OnApplicationQuit(){
		Evertraxx.CamCommunicator.EndCapturing();
	}

}
