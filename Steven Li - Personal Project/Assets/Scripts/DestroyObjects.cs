using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private float zDestroy = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }

    void DestroyObject()
    {
        if (transform.position.z < -zDestroy)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has collided with an object");
            Destroy(gameObject);
        }
    }
}
