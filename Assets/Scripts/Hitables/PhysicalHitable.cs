using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicalHitable : Hitable
{
        public virtual Hitable Init(Vector3 force){
        this.rb.AddForce(force);
        return this;
    }
}
