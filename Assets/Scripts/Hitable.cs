using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hitable : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Collider2D col;
    [SerializeField] float rotationSpeed;
    [SerializeField] ImpactPool impactPool;

    public int Points => this.points;
    
    public virtual Hitable Init(Vector3 force){
        this.rb.AddForce(force);
        return this;
    }

    protected virtual void Update(){
        transform.Rotate(0, 0, Time.deltaTime * this.rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.tag != "Player") return;
        
        this.impactPool.GetImpact().Init(this.transform.position);
        this.Hit(other.gameObject);
    }

    protected abstract void Hit(GameObject other);
    

}
