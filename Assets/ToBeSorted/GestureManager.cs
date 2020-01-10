using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    [SerializeField] GameObject invertedSprite, gesture, exit;
    
    public void Enter(){
        this.invertedSprite.SetActive(true);
        this.exit.SetActive(true);
    }
    public void Exit(){
        this.invertedSprite.SetActive(false);
        this.gesture.SetActive(false);
        PhysicalCanon.speedModifier = 3f;
        Destroy(gameObject);
    }
}
