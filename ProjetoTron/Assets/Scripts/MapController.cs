using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float groundSize = 25f;
    [SerializeField] private GameObject mapPrefab;

    // Start is called before the first frame update
    void Start()
    {
        mapPrefab = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MapMovement();
        MapRemovalAndInsertion();
    }

    void MapMovement()
    {
        Vector2 targetPosition = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        transform.position = targetPosition;
    }

    void MapRemovalAndInsertion()
    {
        
        if (transform.position.x < -groundSize)
        {
            Vector3 newPosition = new Vector3(transform.position.x + groundSize * 2, transform.position.y, transform.position.z); 
            Instantiate(mapPrefab, newPosition, Quaternion.Euler(0, -90, 0), transform.parent);
            Destroy(gameObject);
        }
    }
}
