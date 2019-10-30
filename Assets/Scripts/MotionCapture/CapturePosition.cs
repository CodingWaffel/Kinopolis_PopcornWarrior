using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evertraxx{
    
        
    public struct CapturePosition{
        public bool valid;
        public Vector3 position;

        public CapturePosition(bool valid, Vector3 position){
            this.valid = valid;
            this.position = position;
        }
    }
}