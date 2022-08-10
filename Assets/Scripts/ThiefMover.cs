using UnityEngine;

public class ThiefMover : MonoBehaviour
{
    [SerializeField] private int _speed;

    private bool _isTargetReach;
    private Vector3 _startPosition;
    private Transform _targetPosition;
    private SpriteRenderer _direction;
    private Animator _animator;

    private void Start()
    {
        _targetPosition = GameObject.Find("Target").transform;
        _startPosition = GetComponent<Transform>().position;
        _direction = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (_isTargetReach)
            {
                transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);

                if (transform.position == _startPosition)
                {
                    _direction.flipX = false;

                    _isTargetReach = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, _speed * Time.deltaTime);

                if (transform.position == _targetPosition.position)
                {
                    _direction.flipX = true;

                    _isTargetReach = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Home home))
        {
            _animator.SetTrigger("Home");
        }
    }
}
