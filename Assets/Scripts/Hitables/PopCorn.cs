﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCorn : PhysicalHitable
{
    [SerializeField] float hitForceUp;
    [SerializeField] Animator animator;
    [SerializeField] Sprite[] possiblePopcornSprites;
    [SerializeField] Sprite maizeSprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float rotationSpeed;

    public override Hitable Init(Vector3 force){
        
        this.animator.SetTrigger("Reset");
        this.rb.Sleep();
        this.rb.WakeUp();
        this.col.enabled = true;
        this.spriteRenderer.sprite = this.maizeSprite;
        return base.Init(force);
    }
    protected override void Hit(GameObject other)
    {
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

    protected override void OnUpdate(){
        transform.Rotate(0, 0, Time.deltaTime * this.rotationSpeed);
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