using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nacho : PhysicalHitable
{
    [SerializeField] float fallSpeed = 15f;
    [SerializeField] float rotationSpeed;
    
    protected override void Hit(GameObject other)
    {
        if(other.tag != "Player") return;
        Score.Raise(this.Points);
        gameObject.SetActive(false);
    }

    protected override void OnUpdate(){
        
        transform.position = transform.position + (Vector3.down * Time.deltaTime * this.fallSpeed);
        transform.Rotate(0, 0, Time.deltaTime * this.rotationSpeed);
    }

}
