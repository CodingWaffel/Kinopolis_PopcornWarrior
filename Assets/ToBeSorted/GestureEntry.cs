using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureEntry : MonoBehaviour
{
    [SerializeField] GestureManager gestureManager;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Player") return;
        other.transform.position = this.transform.position;
        this.gestureManager.Enter();   
        gameObject.SetActive(false);
    }
}
