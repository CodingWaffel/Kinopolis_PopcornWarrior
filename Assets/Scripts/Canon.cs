using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    //[SerializeField] Hitable[] hitablePrefabs;
    [SerializeField] PopcornPool popcornPool;
    [SerializeField] float spawnTimeMin, spawnTimeMax, power;
    [SerializeField] Transform bottom, top;

    Transform myTransform;

    float counter;

    void Start(){
        this.myTransform = this.transform;
        this.counter = Random.Range(this.spawnTimeMin, this.spawnTimeMax);
    }

    void Update(){
        this.counter -= Time.deltaTime;

        if(this.counter <= 0){
            this.Fire();
            this.counter = Random.Range(this.spawnTimeMin, this.spawnTimeMax);
        } 
    }


    void Fire(){
        float x = Random.Range(this.bottom.position.x - transform.position.x, this.top.position.x - transform.position.x);
        float y = Random.Range(this.bottom.position.y - transform.position.y, this.top.position.y - transform.position.y);
        Vector3 dir = new Vector3(x, y, 0);
        dir = dir.normalized;
        Hitable popcorn = this.popcornPool.GetHitable();
        popcorn.transform.position = this.myTransform.position;
        popcorn.transform.rotation = Quaternion.Euler(0,0,Random.Range(0, 360));
        popcorn.gameObject.SetActive(true);
        popcorn.Init(dir * this.power);
        
    }
}
