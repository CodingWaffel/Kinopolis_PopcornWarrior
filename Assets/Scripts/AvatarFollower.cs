using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Evertraxx;

public class AvatarFollower : CaptureBody {

    public ImpactPool impactPool;


	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Player" && this.impactPool)
        {
            this.impactPool.GetImpact().Init(transform.position);
        }
    }


}
