using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingImpact : Impact
{
    
    [SerializeField] GameObject flyParticles;

    public override Impact Init(Transform position){
        
        this.flyParticles.transform.LookAt(position.position);
        this.flyParticles.SetActive(true);
        return base.Init(position);
    }


    protected override IEnumerator Play(Transform target){
        StartCoroutine(this.ShowLaser());
        if(this.Audio)
            while(this.Audio.isPlaying){
                yield return new WaitForSeconds(.1f);
            }
        if(this.Particles)
            while(this.Particles.IsAlive()){
                yield return new WaitForSeconds(.1f);
            }
        this.End();
        
    }

    IEnumerator ShowLaser(){
        float counter = 0f;
        while(counter < .1f){
            counter += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        this.flyParticles.SetActive(false);
    }
}
