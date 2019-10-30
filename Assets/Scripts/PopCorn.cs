using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCorn : Hitable
{
    [SerializeField] float hitForceUp;
    [SerializeField] Animator animator;
    [SerializeField] Sprite[] possiblePopcornSprites;
    [SerializeField] Sprite maizeSprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    public override Hitable Init(Vector3 force){
        
        this.animator.SetTrigger("Reset");
        this.rb.Sleep();
        this.rb.WakeUp();
        this.col.enabled = true;
        this.spriteRenderer.sprite = this.maizeSprite;
        transform.localScale *= Random.Range(.95f, 1.05f);
        return base.Init(force);
    }
    protected override void Hit(GameObject other)
    {
        if(other.tag != "Player") return;
        
        Score.Raise(this.Points);
        this.animator.SetTrigger("Pop");
        this.spriteRenderer.sprite = this.possiblePopcornSprites[Random.Range(0, this.possiblePopcornSprites.Length)];
        transform.localScale *= Random.Range(.8f, 1.2f);

        this.col.enabled = false;
        this.rb.Sleep();
        this.rb.WakeUp();
        this.rb.AddForce(Vector3.up * this.hitForceUp);
        StartCoroutine("DeactivateAfter", 1f);
        
    }

    IEnumerable DeactivateAfter(float time){
        float counter = 0f;
        while(counter < time){
            counter += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }

}
