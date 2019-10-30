using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStarter : MenuElement
{

    [SerializeField] GameObject[] activatableObjects;

    public override void Activate(){
        foreach (GameObject obj in this.activatableObjects)
        {
            obj.SetActive(true);
        }
    }
}
