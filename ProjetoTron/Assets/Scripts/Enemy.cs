using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private Transform target;
    public Transform shotPrefab;
    public float speed;
    public float fireRate;
    public float nextFire;
    public float maxChargeTime = 0;
    float currentCharge = 0;
    public GameObject Rastro2;

    void Start() {
        target = GameObject.FindGameObjectWithTag("PlayerObject").GetComponent<Transform>();
       
      
    }

    void Update() {
      
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (currentCharge >= maxChargeTime)
        {
            Rastro2.SetActive(true);
        }
        else
        {
            Rastro2.SetActive(false);
            
        }
    }

    void OnTriggerEnter(Collider hit) {

        //if(hit.tag == "PlayerObject" && Time.time > nextFire){
        //    var shotTransform = Instantiate(shotPrefab) as Transform;
        //    shotTransform.position = transform.position;
        //    Fire();
        //}
        
        if(hit.tag == "Bullet"){

            GameObject.Destroy (gameObject, 0);
        }
    }
     void Fire(){
        nextFire = Time.time + fireRate;
        
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.tag == "PlayerObject")
        {
            currentCharge += Time.deltaTime;
        }
        
    }
    void OnTriggerExit(Collider hit)
    {
            currentCharge = 0;
        
    }
}
