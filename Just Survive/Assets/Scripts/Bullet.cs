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
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
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
