using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evertraxx{
    public class CaptureBody : MonoBehaviour
    {
        [SerializeField] CaptureControl controllerToFollow;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float speed = 20f;

        Transform controller;
        Transform myTransform;


        void Awake(){
            this.controller = this.controllerToFollow.transform;
            this.myTransform = this.transform;
        }
        void FixedUpdate() {
            Vector3 target = this.controller.position;
            Vector3 me = myTransform.position;
            Vector3 nextPos = me + (target - me).normalized * Time.fixedDeltaTime * this.speed;
            
            Vector2 LookAtPoint = new Vector2(target.x, target.y);
            transform.rotation = Quaternion.Euler(0,0, LookAtPoint.y);


            
            this.rb.MovePosition(nextPos);
            
        }
    }
}