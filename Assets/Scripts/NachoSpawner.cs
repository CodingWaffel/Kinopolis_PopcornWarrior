using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NachoSpawner : MonoBehaviour
{
    [SerializeField] Transform leftEdge, rightEdge;
    [SerializeField] float speed = 10f, frequency, duration;
    [SerializeField] PopcornPool pool;
    

    [SerializeField] AnimatedText animatedText;

    float nachoSpawnCounter, activeCounter;

    public float Duration => this.duration;
    public bool Active => this.active;
    public void Activate(){
        this.activeCounter = this.duration;
        this.active = true;
        this.animatedText.Activate();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.nachoSpawnCounter = this.frequency;
    }

    bool movingRight, active;
    void Update()
    {
        if(!active) return;

        if(movingRight){
            transform.Translate(Vector3.right * Time.deltaTime * this.speed);
            if(transform.position.x >= this.rightEdge.position.x) movingRight = false;
        }else{
            transform.Translate(Vector3.left * Time.deltaTime * this.speed);
            if(transform.position.x <= this.leftEdge.position.x) movingRight = true;

        }

        nachoSpawnCounter -= Time.deltaTime;
        if(nachoSpawnCounter <= 0f){
            Hitable nacho = this.pool.GetHitable();
            nacho.transform.position = transform.position;
            nacho.gameObject.SetActive(true);
            //Instantiate(this.nachoPrefab, transform.position, Quaternion.Euler(0,0,Random.Range(0, 360)));
            nachoSpawnCounter = this.frequency;
        }

        this.activeCounter -= Time.deltaTime;
        if(this.activeCounter <= 0f) this.active = false;
    }
}
