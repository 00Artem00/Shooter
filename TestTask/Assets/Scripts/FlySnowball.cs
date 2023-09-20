using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlySnowball : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject snowball;
    [SerializeField] private float speedShoot;
    [SerializeField] private float speedArcher;
    [SerializeField] private float shootInterval;
    [SerializeField] private float distance;
    private bool shouldShoot = true;

    private void Update()
    {
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            transform.Translate(new Vector3(0, 0, speedArcher * Time.deltaTime));    
        }
        else
        {
            if (shouldShoot)
            {
                shouldShoot = false;
                CreateBullet();
                Invoke("ResetShoot", shootInterval);
            }
        }
    }

    private void CreateBullet()
    {
        GameObject bullet = Instantiate(snowball, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speedShoot, ForceMode.Impulse);
        Destroy(bullet, 1.5f);
    }

    private void ResetShoot()
    {
        shouldShoot = true;
    }
}
