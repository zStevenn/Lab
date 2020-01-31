using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private float zDestroy = 10.0f;
    public int PointValue;
    public ParticleSystem explosionParticle;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(PointValue);
        }
    }
}
