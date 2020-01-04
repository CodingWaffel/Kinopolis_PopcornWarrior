using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCanon : MonoBehaviour
{
    [SerializeField] KinematicHitablePool hitablePool;
    [SerializeField] float spawnTimeMin, spawnTimeMax, initialSpeed;
    [SerializeField] Transform target;

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
        

        KinematicHitable hitable = this.hitablePool.GetHitable();

        hitable.transform.position = this.myTransform.position;
        
        float ScaleMod = Random.Range(.95f, 1.05f);
        hitable.transform.localScale *= 1f + (1f - ScaleMod);
        hitable.gameObject.SetActive(true);
        hitable.Init(this.initialSpeed, this.target.position, hitable.Rigidbody);
        
    }
}
