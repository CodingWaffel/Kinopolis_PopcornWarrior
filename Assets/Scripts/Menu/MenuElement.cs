using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuElement : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float durationTillActivation = 1f;
    float counter;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag != "Player") return;

        this.counter = 0;
        this.SetFillAmount();
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.tag != "Player" || counter > this.durationTillActivation) return;
        this.counter += Time.deltaTime;
        this.SetFillAmount();

        if(this.counter >= this.durationTillActivation) this.Activate();
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag != "Player") return;

        this.counter = 0;
        this.SetFillAmount();
        
    }

    void SetFillAmount(){
        this.image.fillAmount = this.counter / this.durationTillActivation;
    }

    public abstract void Activate();
}
