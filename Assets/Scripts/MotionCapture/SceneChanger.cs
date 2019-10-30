using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Evertraxx;

public class SceneChanger : MonoBehaviour {
    public static SceneChanger instance = null;

    public string lastScene = "Menu_Main";
    public Capturing myCapturer;

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

	public void ChangeSceneTo(string sceneName, bool endCapturing){
        lastScene = SceneManager.GetActiveScene().name;
        if (endCapturing)
			Evertraxx.CamCommunicator.EndCapturing();
		SceneManager.LoadScene(sceneName);
	}

    public void ChangeSceneToWithoutEndCapturing(string sceneName)
    {
        lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

	void OnApplicationQuit(){
		Evertraxx.CamCommunicator.EndCapturing();
	}

}
