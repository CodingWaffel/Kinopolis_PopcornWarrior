using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlinker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI blinkingText;
    [SerializeField] float blinkingSpeed = 1f;
    float counter;
    bool counterDir;
    // Start is called before the first frame update
    void Start()
    {
        this.counter = 0;
        this.counterDir = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.counterDir){
            this.counter += Time.deltaTime * this.blinkingSpeed;
            this.blinkingText.alpha = this.counter;
            if(counter >= 1) counterDir = false;
        }else{
            this.counter -= Time.deltaTime * this.blinkingSpeed;
            this.blinkingText.alpha = this.counter;
            if(counter <= 0) counterDir = true;
        }
        
    }
}
