using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRegidbody;

    private void Awake()
    {   
        bulletRegidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 10f;
        bulletRegidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {   
        Destroy(gameObject);
    }

}
