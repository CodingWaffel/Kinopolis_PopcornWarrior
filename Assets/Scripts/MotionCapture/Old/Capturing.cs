using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Evertraxx{
    public class Capturing : MonoBehaviour{

        public static Capturing instance;
        public bool shouldCapture;
        bool isCapturing;
        // Use this for initialization
        void Awake () {
            if(instance == null){
                instance = this;
                DontDestroyOnLoad(gameObject);
                StartCoroutine(this.StartCapturing());
            }else{
                if(instance != this){
                    Destroy(gameObject);
                }
            }
        }

        IEnumerator StartCapturing(){
            /*CamCommunicator.SetCoef(3.5f);
            CamCommunicator.SetStab(30);
            CamCommunicator.SetSens(5);
            CamCommunicator.SetCountMin(5);*/
            yield return new WaitForSeconds(.1f);

            CamCommunicator.StartCapturing();
            shouldCapture = true;
            isCapturing = true;
        }

        void Update()
        {
            if(shouldCapture && !isCapturing)
            {
                CamCommunicator.StartCapturing();
                isCapturing = true;
            }
            if(!shouldCapture && isCapturing)
            {
                CamCommunicator.EndCapturing();
                isCapturing = false;
            }
        }

        void OnApplicationQuit(){
            CamCommunicator.EndCapturing();
            isCapturing = false;
        }


    }
}