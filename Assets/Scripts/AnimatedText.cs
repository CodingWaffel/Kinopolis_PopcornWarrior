using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimatedText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI animatedText;
    [SerializeField] float animationDuration;
    [SerializeField] float animationSpeed;
    [SerializeField] Vector2 minMaxFontSize;

    float counter = 0f;
    bool active = false;
    bool increseSize;
    public void Activate(){
        this.animatedText.gameObject.SetActive(true);
        this.counter = 0f;
        this.active = true;
        this.increseSize = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(!this.active) return;

        counter += Time.deltaTime;

        this.animatedText.fontSize += this.increseSize ? Time.deltaTime * this.animationSpeed : -Time.deltaTime * this.animationSpeed;

        if(this.increseSize && this.animatedText.fontSize >= this.minMaxFontSize.y) this.increseSize = false;
        if(!this.increseSize && this.animatedText.fontSize <= this.minMaxFontSize.x) this.increseSize = true;

        if(this.counter >= this.animationDuration){
            this.active = false;
            this.animatedText.gameObject.SetActive(false);
        }

    }
}
