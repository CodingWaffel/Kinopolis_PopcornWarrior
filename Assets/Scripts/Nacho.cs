using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nacho : Hitable
{
    protected override void Hit(GameObject other)
    {
        if(other.tag != "Player") return;
        Score.Raise(this.Points);
        Destroy(gameObject);
    }

    protected override void Update(){
        
        transform.position = transform.position + (Vector3.down * Time.deltaTime * 15);
        base.Update();
    }

}
