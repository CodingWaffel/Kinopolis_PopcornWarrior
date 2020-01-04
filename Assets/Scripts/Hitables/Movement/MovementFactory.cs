using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementFactory : ScriptableObject
{
    public float maxDistanceFromTarget = 10;
    public float speed;
    public abstract KinematicMovement Create(Vector2 target, Rigidbody2D rigidbody);

    public Vector2 GetNewTarget(Vector2 target){
        float x = target.x + Random.Range(- this.maxDistanceFromTarget/2, this.maxDistanceFromTarget/2);
        float y = target.y + Random.Range(- this.maxDistanceFromTarget/2, this.maxDistanceFromTarget/2);
        return new Vector2(x, y);
    }
}

public enum AnimationState{
    Front, Side
}
