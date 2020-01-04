using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Evertraxx{
    
  /// <summary>
  /// CamCommunicator working with openCvForUnity
  /// </summary>
  public class CamCommunicatorTwo : AbstractCamCommunicator
  {
      [SerializeField] Traxx traxx;

      static Position position;
        //Returns the Screen coordinates of the moving object relative to a given Camera
      public override CapturePosition CalcMovementPosition(Camera cam){  
        position = this.traxx.GetPosition();

        float xs =(float) ((cam.pixelRect.xMax*1.4*position.x/position.w) - cam.pixelRect.xMax*.2);
        if(xs < 0) xs = 0;
        if(xs > cam.pixelRect.xMax) xs = cam.pixelRect.xMax;

        float ys = (float) ((cam.pixelRect.yMax*1.4*position.y/position.h) - cam.pixelRect.yMax*.2);
        if(ys < 0) ys = 0;
        if(ys > cam.pixelRect.yMax) ys = cam.pixelRect.yMax;

        Vector3 returnValue = new Vector3(xs,Screen.height - ys, 0);

        if(float.IsNaN(returnValue.x) || float.IsNaN(returnValue.y)){
          return new CapturePosition(false, Vector3.zero);
        }else{
          return new CapturePosition(true, returnValue);
        }
      }
  }
}