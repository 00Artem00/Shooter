using Unity.VisualScripting;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private string _tag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthPlayer health = collision.gameObject.GetComponent<HealthPlayer>();
            health.TakeDamage(_damage);
            if (_tag == "Snowball")
            {
                Destroy(gameObject);
            }
        }
    }

  
}
