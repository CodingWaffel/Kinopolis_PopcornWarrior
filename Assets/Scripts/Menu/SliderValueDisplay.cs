using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Evertraxx;

public class SliderValueDisplay : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] DisplayValue displayValue;
    // Start is called before the first frame update
    void Start()
    {
        switch(this.displayValue){
            case DisplayValue.Coef:
                this.textMesh.text = CamCommunicator.GetCoef().ToString("F2");
                this.slider.value = CamCommunicator.GetCoef();
                break;
            case DisplayValue.Stab:
                this.textMesh.text = CamCommunicator.GetStab().ToString();
                this.slider.value = CamCommunicator.GetStab();
                break;
            case DisplayValue.Sens:
                this.textMesh.text = CamCommunicator.GetSens().ToString();
                this.slider.value = CamCommunicator.GetSens();
                break;
            case DisplayValue.CountMin:
                this.textMesh.text = CamCommunicator.GetCountMin().ToString();
                this.slider.value = CamCommunicator.GetCountMin();
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
            case DisplayValue.Coef:
                CamCommunicator.SetCoef(Mathf.Round(2*value)/2);
                this.textMesh.text = (Mathf.Round(2*value)/2).ToString("F2");
                break;
            case DisplayValue.Stab:
                CamCommunicator.SetStab((int)value);
                break;
            case DisplayValue.Sens:
                CamCommunicator.SetSens((int)value);
                break;
            case DisplayValue.CountMin:
                CamCommunicator.SetCountMin((int)value);
                break;
            default:
                this.textMesh.text = "Value not known...";
                break;
        }
    }

}

public enum DisplayValue{
    Coef, Stab, Sens, CountMin
}