using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rastro : MonoBehaviour
{
    public float speed;
    public float livingTime = 3f;
    public float _startingTime;

    void Start(){
        _startingTime = Time.time;
        //Destroy(gameObject, livingTime);
    }

    void Update (){
        transform.Translate (Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider hit) {
        
        /*if(hit.tag == "Enemy"){

            GameObject.Destroy (gameObject, 0);
        }*/
    }
}

