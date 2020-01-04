using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hitable : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Collider2D col;
    [SerializeField] ImpactPool impactPool;

    public int Points => this.points;
    public Rigidbody2D Rigidbody => this.rb;
    


    void Update(){
        this.OnUpdate();
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.tag != "Player") return;
        
        this.impactPool.GetImpact().Init(this.transform);
        this.Hit(other.gameObject);
    }

    protected abstract void Hit(GameObject other);

    protected virtual void OnUpdate(){}
    

}
