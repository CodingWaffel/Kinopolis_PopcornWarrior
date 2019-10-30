using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Image timeDisplayImage;
    [SerializeField] TextMeshProUGUI timeDisplayText;

    void Update()
    {
        if(this.timeDisplayImage){
            this.timeDisplayImage.fillAmount = this.timer.TimeLeft / (float)this.timer.MaxTime;
        }

        if(this.timeDisplayText){
            this.timeDisplayText.text = this.timer.TimeLeft.ToString("F0");
        }
    }
}
