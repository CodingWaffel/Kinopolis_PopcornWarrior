using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nacho : Hitable
{
    [SerializeField] float fallSpeed = 15f;
    
    protected override void Hit(GameObject other)
    {
        if(other.tag != "Player") return;
        Score.Raise(this.Points);
        gameObject.SetActive(false);
    }

    protected override void Update(){
        
        transform.position = transform.position + (Vector3.down * Time.deltaTime * this.fallSpeed);
        base.Update();
    }

}
