using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/StraightMovement")]
public class StraightMovementFactory : MovementFactory
{
    public override KinematicMovement Create(Vector2 target, Rigidbody2D rigidbody)
    {

        return new StraightMovement(speed, this.GetNewTarget(target), rigidbody);
    }
}
