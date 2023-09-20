using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Scripting;
using UnityEditor.PackageManager;

public class RaycastAttack : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField, Min(0f)] private float _damage = 10f;

    [Header("Ray")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Min(0f)] private float _distance = Mathf.Infinity;
    [SerializeField, Min(0f)] private int _shotCount = 1;
    [SerializeField, Min(0f)] private float forceNext;
    [SerializeField, Min(0f)] private float shootInterval;
    [SerializeField, Min(0f)] private float sphereRadius;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource audioSource;
    private bool shouldShoot = true;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && shouldShoot)
        {
            shouldShoot = false;
            PerformAttack();
            _particleSystem.Play();
            audioSource.Play();
            Invoke("ResetShoot", shootInterval);
        }
    }

    public void PerformAttack()
    {
        for (var i = 0; i < _shotCount; i++)
        {
            PerformRaycast();
        }
    }

    private void PerformRaycast()
    {
        var direction = transform.forward;
        var ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            var hitCollider = hitInfo.collider;
            var hitRigidbody = hitInfo.rigidbody;

            if (hitCollider.transform.tag == "Enemy")
            {
                HealthEnemy health = hitCollider.gameObject.GetComponent<HealthEnemy>();
                health.TakeDamage(_damage);
                hitRigidbody.AddForce(transform.forward * forceNext, ForceMode.Impulse);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, _distance, _layerMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            var hitPosition = ray.origin + ray.direction * _distance;

            DrawRay(ray, hitPosition, _distance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }

    private void ResetShoot()
    {
        shouldShoot = true;
    }
}
