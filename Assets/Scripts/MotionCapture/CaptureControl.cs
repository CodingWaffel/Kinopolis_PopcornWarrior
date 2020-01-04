using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evertraxx{


    public abstract class CaptureControl : MonoBehaviour
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
        protected abstract void Move();
    }
}