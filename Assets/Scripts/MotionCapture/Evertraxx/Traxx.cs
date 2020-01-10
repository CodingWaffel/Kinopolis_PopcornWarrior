using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.UnityUtils.Helper;


namespace Evertraxx{
        
    [RequireComponent(typeof(WebCamTextureToMatHelper))]
    public class Traxx : MonoBehaviour
    {
        
        [SerializeField] Renderer renderTo;
        [SerializeField] bool renderImage;
        public static Traxx instance;
        int x,y, x0, y0, xc0, yc, yc0, count, w, h;
        Mat imageF, image, frameSub, frame0, ch, frameIn;
        int firstFlg;
        List<Mat> channels;
        /*
            classic/old: coef = 3.6, stab = 200, sens = 3
            newer recommendation: coef = 5.5, stab = 5, sens = 1

        */
        [SerializeField] float coef = 5.5f;
        [SerializeField] int stab = 5;
        [SerializeField] int sens = 5;
        [SerializeField] int countMin = 5;
        WebCamTextureToMatHelper webCamTextureToMatHelper;
        Texture2D texture;
        /// <summary>
        /// The rgb mat.
        /// </summary>
        Mat rgbMat;

        /// <summary>
        /// The fgmask mat.
        /// </summary>
        Mat fgmaskMat;
        int flagM;
        void Awake() {

            this.webCamTextureToMatHelper = GetComponent<WebCamTextureToMatHelper> ();
        }
        void Start()
        {
                instance = this;
                #if UNITY_ANDROID && !UNITY_EDITOR
                // Avoids the front camera low light issue that occurs in only some Android devices (e.g. Google Pixel, Pixel2).
                webCamTextureToMatHelper.avoidAndroidFrontCameraLowLightIssue = true;
                #endif
                if(!webCamTextureToMatHelper.IsInitialized())
                    webCamTextureToMatHelper.Initialize ();

                this.channels = new List<Mat>();
                flagM = -1;
        }

        public Position GetPosition(){
            return new Position(x, y, w, h);
        }

        bool ETraxx(Mat frame){
            if(frame == null) return false;
            if(frame.empty()) return false;


            Size size = new Size((frame.cols() / coef), frame.rows() / coef);
            Mat tmpMat = frame.clone();
            Imgproc.resize(frame, tmpMat, size);
            //Core.flip(tmpMat, tmpMat, 0);

            frameIn = tmpMat.clone();

            h = tmpMat.rows();
            w = tmpMat.cols();

            image = tmpMat.clone();

            if(firstFlg == 0){
                frame0 = tmpMat.clone();
                firstFlg = 1;
                ch = Mat.zeros(image.rows(), image.cols(), 1);
                channels = new List<Mat>(){ch, ch, ch, ch};
                xc0 = (int) (0.5f * w);
            }

            Imgproc.cvtColor(tmpMat, tmpMat, 44, 0);
            Core.split(tmpMat, channels);
            channels[0].setTo(new Scalar(100d));
            Core.merge(channels, tmpMat);
            Imgproc.cvtColor(tmpMat, tmpMat, 56);

            frameSub = frame0 - tmpMat;

            frame0 = tmpMat.clone();
            Imgproc.cvtColor(frameSub, image, 6);
            Imgproc.threshold(image, image, sens, 255, 0);
            imageF = image.clone();

            int xCalc = 0;  
            int yCalc = 0;
            count = 0;

            int nb = 1;
            int nbM = ((2*nb+1)*(2*nb+1)-1);

            for(int row = nb; row < image.rows() - nb; row++){
                for(int col = nb; col < image.cols() - nb; col++ ){

                    if(image.get(row, col)[0] != 0 ){ // no clue why its a double array....
                    
                        int sum = 0;
                        for(int ii = -nb; ii < nb + 1; ii++){
                            for(int jj = -nb; jj < nb + 1; jj++){
                                
                                if(image.get((row + ii), col + jj)[0] != 0){
                                    sum++;
                                }
                            }
                        }

                        if(sum > nbM){
                            xCalc += col;
                            yCalc += row;
                            count++;
                        }
                    }

                }
            }
            if (count >countMin){ 
                xCalc += x0*stab ;
                yCalc += y0*stab;
                xCalc /= count + stab;
                yCalc /= count + stab;
            }else{
                xCalc = x0;
                yCalc = y0;
            }

            x0 = xCalc;
            y0 = yCalc;

            xCalc=(int)(1.4*xCalc -.2*w);
            if (xCalc < 0) xCalc = 0;
            if (xCalc > w) xCalc =w;
            yCalc = (int)(1.4*yCalc - .2*h);
            if (yCalc < 0) yCalc = 0;
            if (yCalc > h) yCalc = h;

            x = xCalc;
            y = yCalc;
            
            return true;
        }   
        



        void Update()
        {
            if (webCamTextureToMatHelper.IsPlaying () && webCamTextureToMatHelper.DidUpdateThisFrame ()) {
                Mat rgbaMat = webCamTextureToMatHelper.GetMat ();

                if(this.renderImage)
                    Utils.fastMatToTexture2D (rgbaMat, texture);

                ETraxx(rgbaMat);
                flagM = 0;
                if(yc > .65 * h){ 
                    flagM = 1;
                }else if(yc < .35 * h){
                    yc0 =(int)(.5f * h);
                    flagM = 2;
                }
            }
        }
        /// <summary>
        /// Raises the webcam texture to mat helper initialized event.
        /// </summary>
        public void OnWebCamTextureToMatHelperInitialized ()
        {
            //Debug.Log ("OnWebCamTextureToMatHelperInitialized");

            Mat webCamTextureMat = webCamTextureToMatHelper.GetMat ();

            if(this.renderImage){
                texture = new Texture2D (webCamTextureMat.cols (), webCamTextureMat.rows (), TextureFormat.RGBA32, false);
                Utils.fastMatToTexture2D(webCamTextureMat, texture);
                this.renderTo.material.mainTexture = texture;
            }

            rgbMat = new Mat (webCamTextureMat.rows (), webCamTextureMat.cols (), CvType.CV_8UC3);
            fgmaskMat = new Mat (webCamTextureMat.rows (), webCamTextureMat.cols (), CvType.CV_8UC1);
        }
        /// <summary>
        /// Raises the webcam texture to mat helper disposed event.
        /// </summary>
        public void OnWebCamTextureToMatHelperDisposed ()
        {
            Debug.Log ("OnWebCamTextureToMatHelperDisposed");
            if (rgbMat != null)
                rgbMat.Dispose ();

            if (fgmaskMat != null)
                fgmaskMat.Dispose ();

            if (texture != null) {
                Texture2D.Destroy (texture);
                texture = null;
            }
        }

        /// <summary>
        /// Raises the webcam texture to mat helper error occurred event.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public void OnWebCamTextureToMatHelperErrorOccurred (WebCamTextureToMatHelper.ErrorCode errorCode)
        {
            Debug.Log ("OnWebCamTextureToMatHelperErrorOccurred " + errorCode);
        }
    }
}