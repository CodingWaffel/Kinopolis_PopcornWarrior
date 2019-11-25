using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCanon : MonoBehaviour
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
        float x = this.target.position.x + Random.Range(-5f, 5f);
        float y = this.target.position.y + Random.Range(-5f, 5f);
        Vector3 dir = new Vector3(x, y, 0);

        KinematicHitable hitable = this.hitablePool.GetHitable();

        hitable.transform.position = this.myTransform.position;
        
        float ScaleMod = Random.Range(.95f, 1.05f);
        hitable.transform.localScale *= 1f + (1f - ScaleMod);
        hitable.gameObject.SetActive(true);
        hitable.Init(new KinematicMovement[]{new StraightMovement(this.initialSpeed, dir, hitable.Rigidbody), new NoMovement(this.initialSpeed, dir, hitable.Rigidbody)});
        
    }
}
