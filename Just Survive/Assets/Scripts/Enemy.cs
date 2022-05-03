using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    public void OnHit() 
    {
        Destroy(gameObject);
    }

    private void Start()
    {
         _target = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
