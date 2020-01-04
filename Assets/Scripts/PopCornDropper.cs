using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCornDropper : MonoBehaviour
{
    [SerializeField] GameObject[] popCornPrefab2;
    [SerializeField] Timer timer;
    

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.DropPopCorn());        
    }



    IEnumerator DropPopCorn(){
        while(counter <= Score.currentScore * .1f){
            Instantiate(this.popCornPrefab2[Random.Range(0, this.popCornPrefab2.Length)], transform.position + new Vector3(Random.Range(-.2f, .2f), 0, 0), Quaternion.identity);
            counter++;
            yield return new WaitForSeconds(.07f);
        }
        this.timer.time = PlayerPrefsManager.GetScoreDuration();
        this.timer.StartTimer();
    }
}
