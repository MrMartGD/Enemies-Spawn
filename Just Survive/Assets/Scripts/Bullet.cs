using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _lifeTime = 2f;
    
    private void Update()
    {
        TrackLifeTime();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy) 
        {
            enemy.OnHit();
            Destroy(gameObject);
        }
    }

    private void TrackLifeTime() 
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
