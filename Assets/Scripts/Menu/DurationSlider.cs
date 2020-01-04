using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DurationSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] DurationType displayValue;
    // Start is called before the first frame update
    void Start()
    {
        switch(this.displayValue){
            case DurationType.Start:
                this.textMesh.text = PlayerPrefsManager.GetStartDuration().ToString("F0");
                this.slider.value = PlayerPrefsManager.GetStartDuration();
                break;
            case DurationType.Game:
                this.textMesh.text = PlayerPrefsManager.GetGameDuration().ToString("F0");
                this.slider.value = PlayerPrefsManager.GetGameDuration();
                break;
            case DurationType.Score:
                this.textMesh.text = PlayerPrefsManager.GetScoreDuration().ToString("F0");
                this.slider.value = PlayerPrefsManager.GetScoreDuration();
                break;
            default:
                this.textMesh.text = "Value not known...";
                break;
        }
        this.slider.onValueChanged.AddListener(this.Display);
    }

    void Display(float value){
        this.textMesh.text = value.ToString("F0");

        switch(this.displayValue){
            case DurationType.Start:
                PlayerPrefsManager.SetStartDuration((int)value);
                this.textMesh.text = value.ToString("F0");
                break;
            case DurationType.Game:
                PlayerPrefsManager.SetGameDuration((int)value);
                this.textMesh.text = value.ToString("F0");
                break;
            case DurationType.Score:
                PlayerPrefsManager.SetScoreDuration((int)value);
                this.textMesh.text = value.ToString("F0");
                break;
            default:
                this.textMesh.text = "Value not known...";
                break;
        }
    }
}

public enum DurationType{
    Start, Game, Score
}
