using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evertraxx{
        
    public abstract class AbstractCamCommunicator : MonoBehaviour
    {
        public abstract CapturePosition CalcMovementPosition(Camera cam);
    }
}