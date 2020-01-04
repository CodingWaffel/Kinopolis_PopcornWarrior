using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : KinematicHitable
{
    [SerializeField] int live = 1;
    [SerializeField] ParticleSystem motorParticles;
    [SerializeField] SpriteRenderer mySprite;
    [SerializeField] Animator animator;
    int currentLive;
    public override Hitable Init(float speed, Vector2 target, Rigidbody2D rigidbody){
        this.col.enabled = true;
        this.currentLive = live;
        if(this.motorParticles)
            this.motorParticles.Play();
        return base.Init(speed, target, rigidbody);
    }
    protected override void Hit(GameObject other)
    {
        if(other.tag != "Player") return;
        this.currentLive--;
        if(this.currentLive <= 0){
            Score.Raise(this.Points);
            this.col.enabled = false;
            this.animator.SetTrigger("Die");
            
        }
        
    }
    public override void Move(){
        if(this.movement[this.iterator].Move()){
            if(this.movement.Length > this.iterator + 1){
                this.iterator++;
                this.animator.SetTrigger("Turn");
            }
        }else{

        }
    }


    public void Deactivate(){
        gameObject.SetActive(false);
        
    }
}
