using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCornDropper : MonoBehaviour
{
    [SerializeField] GameObject popCornPrefab;
    [SerializeField] Timer timer;
    

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.DropPopCorn());        
    }



    IEnumerator DropPopCorn(){
        while(counter <= Score.currentScore){
            Instantiate(this.popCornPrefab, transform.position + new Vector3(Random.Range(-.2f, .2f), 0, 0), Quaternion.identity);
            counter++;
            yield return new WaitForSeconds(.07f);
        }
        this.timer.StartTimer();
    }
}
