using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evertraxx{


    public class CaptureControl : MonoBehaviour
    {
        [SerializeField] Camera cam;
        protected Camera Cam => this.cam;

        void Start () {
            if(!this.cam)
                this.cam = FindObjectOfType<Camera>();

        }

        // Update is called once per frame
        void Update()
        {
            this.Move();
        }
        protected virtual void Move(){
            CapturePosition tmp = CamCommunicator.CalcMovementPosition(Cam);
            if (!tmp.valid) return;


            Vector3 originalPosition = Cam.ScreenToWorldPoint(tmp.position);
            originalPosition.z = 0;
            transform.position = originalPosition;

        }
    }
}