using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleSceneStarterView : MonoBehaviour
{
    [SerializeField] Image loadingbar;
    [SerializeField] SingleSceneStarter sceneStarter;
    float staringTime;
    
    void Start(){
        Cursor.visible = false;
        this.staringTime = this.sceneStarter.time;
    }
    void Update()
    {
        this.loadingbar.fillAmount = 1 - (this.sceneStarter.time / this.staringTime);
    }
}
