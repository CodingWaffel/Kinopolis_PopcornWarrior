using System.Runtime.InteropServices;
using UnityEngine;
using System.Threading;

namespace Evertraxx{
  
  /*
  This class is to handle the nuiy.dll
  Need to use:
    void StartCapturing()
    void EndCapturing()
    Vector3 CalcMovementPosition(Camera cam)
    void MoveAvatar(Vector3 screenCoordinates, GameObject movingObject, Camera cam)

    Create a GameObject that calls StartCapturing(); A new Thread will be opened that initializes the Webcam.
    Now you cann call MoveAvatar preferebly with CalMovementPosition as parameter to get a Vector3 you can assign to a transform.position.

    Remember to call EndCapturing(); !!


    Known Issues:
      When initially started there will be a error that can be ignored. Before the first movement, there is No Number to send, therefore its not in the screenspace.

  */
  public static class CamCommunicator{
      
    [DllImport("NUIY")]
    public static extern bool InCapturing();
    [DllImport("NUIY")]
    //start Capturing of movement. Remember to endCapturing!!!
    private static extern void startCapturing();
    [DllImport("NUIY")]
    private static extern void endCapturing();

    //Used to calculate the Movement Position
    [DllImport("NUIY")]
    public static extern float GetX();
    [DllImport("NUIY")]
    public static extern float GetY();
    [DllImport("NUIY")]
    public static extern float GetH();
    [DllImport("NUIY")]
    public static extern float GetW();
    [DllImport("NUIY")]
    public static extern float GetDuration();

    private static Thread thread;

    static int captureCheck = 0;
    /*
    start new Thread for motion capture in background
    */
    public static void StartCapturing(){

      if(InCapturing()) return;

      x = GetX();
      y = GetY();

      Application.targetFrameRate = 30;
      thread = new Thread(startCapturing);
      thread.Start();
      thread.IsBackground = true;
    }

    /*
    stop capturing and abort the thread
    */
    public static void EndCapturing(){
      if(thread != null){
        endCapturing();
        thread.Abort();
      }
    }

    static float x, y;
      //Returns the Screen coordinates of the moving object relative to a given Camera
    public static CapturePosition CalcMovementPosition(Camera cam){  

      if(!InCapturing()){
        captureCheck++;
        if(captureCheck == 180){
          EndCapturing();
          StartCapturing();
          captureCheck = 0;
        }
        return new CapturePosition(false, Vector3.zero);

      }else{
        captureCheck = 0;
      }

      if(x == GetX() && y == GetY()){

        return new CapturePosition(false, Vector3.zero);
      }
      x = GetX();
      y = GetY();


      float xs =(float) ((cam.pixelRect.xMax*1.4*GetX()/GetW()) - cam.pixelRect.xMax*.2);
      if(xs < 0) xs = 0;
      if(xs > cam.pixelRect.xMax) xs = cam.pixelRect.xMax;

      float ys = (float) ((cam.pixelRect.yMax*1.4*GetY()/GetH()) - cam.pixelRect.yMax*.2);
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