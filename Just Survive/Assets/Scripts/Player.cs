using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _bulletCreator;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedBullet = 20f;
        
    private float _angle;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Rotate();
        Shoot();
    }

    private void Rotate() 
    {
        _angle += Input.GetAxis("Horizontal") * _speedRotate * Time.deltaTime;
        _angle = Mathf.Clamp(_angle, -90, -10);
        transform.localRotation = Quaternion.AngleAxis(_angle, Vector3.up);
    }

    private void Shoot() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Ray ray = new Ray(_bulletCreator.position, _bulletCreator.forward);

            Rigidbody newBullet = Instantiate(_bullet, _bulletCreator.position, _bulletCreator.rotation);
            newBullet.velocity = ray.direction * _speedBullet;
                        
            _shootSound.pitch = Random.Range(0.8f, 1.4f);
            _shootSound.Play();
            
            _animator.SetTrigger(AnimatorPlayerController.States.Shoot);
        }
    }
}
