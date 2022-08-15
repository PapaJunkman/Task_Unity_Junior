using UnityEngine;

public class ThiefMover : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private int _speed;

    private bool _isTargetReach;
    private Vector3 _startPosition;
    private SpriteRenderer _direction;

    private const string Home = "Home";
    private const string Walk = "Walk";

    private void Start()
    {
        _startPosition = GetComponent<Transform>().position;
        _direction = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(Walk))
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
            _animator.SetTrigger(Home);
        }
    }
}