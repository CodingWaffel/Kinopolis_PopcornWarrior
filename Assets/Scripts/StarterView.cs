using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterView : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] Starter starter;

    void Update(){
        this.bar.fillAmount = this.starter.GameChooseCounter;
    }

}
