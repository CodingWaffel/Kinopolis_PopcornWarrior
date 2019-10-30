using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evertraxx{
    public class CaptureBody : MonoBehaviour
    {
        [SerializeField] CaptureControl controllerToFollow;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float speed = 20f;
        [SerializeField] float minimumRotationDistance = 1f;

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
            
            if(Vector3.Distance(me, target) < this.minimumRotationDistance){
                //this.rb.MoveRotation(Mathf.MoveTowardsAngle(this.rb.rotation, 0, Time.fixedDeltaTime * 360f));
            }else{
                //this.rb.SetRotation((target.x >= me.x) ? Vector3.Angle(Vector3.down, (target - me).normalized) : -Vector3.Angle(Vector3.down, (target - me).normalized));
                //this.rb.SetRotation((nextPos.x >= me.x) ? Vector3.Angle(Vector3.down, (nextPos - me).normalized) : -Vector3.Angle(Vector3.down, (nextPos - me).normalized));
            }

            
            this.rb.MovePosition(nextPos);
        }
    }
}