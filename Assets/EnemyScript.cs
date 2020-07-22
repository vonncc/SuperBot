using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelTransform;

    public float shootIterator = 1f;
    bool canShoot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("yeeet");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("yeeet");
        }
    }

    IEnumerator ShootBullet()
    {
        while(canShoot)
        {
            print("shoot");
            Instantiate(bulletPrefab, barrelTransform.position, barrelTransform.rotation);
            yield return new WaitForSeconds(shootIterator);
        }
    }

    public void StartShoot()
    {
        canShoot = true;
        //bla += 1;
        //print(bla);
        StartCoroutine("ShootBullet");
    }

    public void StopShoot()
    {
        canShoot = false;
        StopCoroutine("ShootBullet");
    }
    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
