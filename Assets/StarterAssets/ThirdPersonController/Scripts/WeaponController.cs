using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    public LayerMask hittableLayers;
    public GameObject bulletHolePrefab;

    [Header("Shoot Parameters")]
    public float fireRange = 200;

    private Transform cameraPlayerTransform;

    void Start()
    {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        HandleShoot();
    }

    // private IEnumerator DestroyEnemyAfterDelay(GameObject enemy, float delay)
    // {
    //     // yield return new WaitForSeconds(delay);
    //     Destroy(enemy);
    // }

    private void HandleShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, fireRange, hittableLayers))
            {
                GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                Destroy(bulletHoleClone, 4f);

                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Disparo");
                    // StartCoroutine(DestroyEnemyAfterDelay(hit.collider.gameObject, 1f));
                    Destroy(hit.collider.gameObject, 1f);
                }
            }
        }
    }

}
