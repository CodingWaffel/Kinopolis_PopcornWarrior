﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public Impact Init(Vector3 position){
        this.transform.position = position;
        gameObject.SetActive(true);
        StartCoroutine(this.Play());
        return this;
    }

    public void End(){
        gameObject.SetActive(false);
    }

    IEnumerator Play(){
        while(this.audioSource.isPlaying){
            yield return new WaitForSeconds(.1f);
        }
        this.End();
    }
}
