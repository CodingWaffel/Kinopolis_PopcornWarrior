using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem particleSys;
    public AudioSource Audio => this.audioSource;
    public ParticleSystem Particles => this.particleSys;
    public virtual Impact Init(Transform position){
        gameObject.SetActive(false);
        this.transform.position = position.position;
        this.audioSource.pitch = Random.Range(.8f, 1.1f);
        gameObject.SetActive(true);
        StartCoroutine(this.Play(position));
        return this;
    }

    public void End(){
        gameObject.SetActive(false);
    }

    protected virtual IEnumerator Play(Transform target){
        if(this.audioSource)
            while(this.audioSource.isPlaying){
                yield return new WaitForSeconds(.1f);
            }
        if(this.particleSys)
            while(this.particleSys.IsAlive()){
                yield return new WaitForSeconds(.1f);
            }
        this.End();
    }
}
