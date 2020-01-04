using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneChangerOnKey : MonoBehaviour
{
    public string sceneName;
    public KeyCode key;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(this.key)){
            this.ChangeScene();
        }
    }
    public void ChangeScene(){
        SceneManager.LoadScene(this.sceneName);
    }
}
