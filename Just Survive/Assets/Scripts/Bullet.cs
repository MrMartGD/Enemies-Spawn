using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _lifeTime = 2f;

    private void Awake()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.OnHit();
            Destroy(gameObject);
        }
    }    
}
