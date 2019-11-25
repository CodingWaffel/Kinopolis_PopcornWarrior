using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidekickSpaceship : KinematicHitable
{
    protected override void Hit(GameObject other)
    {
        if(other.tag != "Player") return;
        Score.Raise(this.Points);
        gameObject.SetActive(false);
    }

}
