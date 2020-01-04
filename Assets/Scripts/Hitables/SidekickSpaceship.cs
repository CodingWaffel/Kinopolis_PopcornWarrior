using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidekickSpaceship : KinematicHitable
{
    [SerializeField] int live = 1;
    [SerializeField] ParticleSystem dieParticles, motorParticles;
    [SerializeField] SpriteRenderer mySprite;
    int currentLive;
    public override Hitable Init(float speed, Vector2 target, Rigidbody2D rigidbody){
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
            if(this.dieParticles){
                StartCoroutine(this.Die());
            }else{
                gameObject.SetActive(false);
            }
            
        }
        
    }

    IEnumerator Die(){
        this.mySprite.enabled = false;
        if(this.motorParticles)
            this.motorParticles.Stop();
        this.dieParticles.Play();

        while(this.dieParticles.IsAlive()){
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
        this.mySprite.enabled = true;
    }

}
