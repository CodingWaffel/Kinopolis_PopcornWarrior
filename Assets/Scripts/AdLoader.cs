using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
public class AdLoader : MonoBehaviour
{
    [SerializeField] Image image;
    string path;


    void Awake()
    {
        this.path = $"{Application.streamingAssetsPath}/AdBanner";

        var info = new DirectoryInfo(this.path);
        var fileInfo = info.GetFiles();
        List<string> paths = new List<string>();
        foreach (FileInfo item in fileInfo)
        {
            if(!item.Name.Contains(".meta")){
                paths.Add($"{this.path}/{item.Name}");
            }
            
        }
        string rand = $"{paths[Random.Range(0, paths.Count())]}";
        Texture2D tex = null;
        byte[] fileData;
    
        if (File.Exists(rand))     {
            fileData = File.ReadAllBytes(rand);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }else{
            image.enabled = false;
        }

        image.preserveAspect = true;
        image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(.5f,.5f));
        image.transform.position = Vector3.zero;
        
        
        
        image.rectTransform.position = Vector2.zero;
        
        

    }

}
