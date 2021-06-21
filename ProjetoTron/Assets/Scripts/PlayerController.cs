using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    //Variáveis para tiro do rastro
    public Transform _firePoint;
    public GameObject Rastro;
    public float fireRate;
    public float nextFire;
    public Rigidbody rb;
    public Animator animator;
    Vector3 movement;
    public float speedPlayer;
    public GameObject Rastro2;
    public float maxChargeTime = 0;
    float currentCharge = 0;

    void Awake(){
        _firePoint = transform.Find("FirePoint");
     }
    void Start(){
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            currentCharge += Time.deltaTime;
        }
        else
        {
            currentCharge = 0;
        }

        if (currentCharge >= maxChargeTime)
        {
            Rastro2.SetActive(true);
            movement.x = 0;
            movement.z = 0;
        }
        else
        {
            Rastro2.SetActive(false);
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
            
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speedPlayer * Time.fixedDeltaTime);
    }

    //Método para atirar rastro
    void Fire(){
        nextFire = Time.time + fireRate;

        GameObject cloneBullet = Instantiate (Rastro, _firePoint.position, Quaternion.identity) as GameObject;

    }

    void OnTriggerEnter(Collider hit) {
        
        if(hit.tag == "EnemyBullet"){
            gameObject.SetActive(false);
            Debug.Log("Collider name: " + hit.name);
            Debug.Log("Collider position: " + hit.transform.position);
            ReloadLevel();
            
        }
    }
    

    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
   
   
}
