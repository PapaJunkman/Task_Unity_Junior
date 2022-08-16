using UnityEngine;

public class ThiefMover : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private int _speed;

    private Vector3 _startPosition;
    private SpriteRenderer _direction;

    private const string Home = "Home";
    private const string Walk = "Walk";

    private void Start()
    {
        _startPosition = transform.position;
        _direction = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(Walk))
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, _speed * Time.deltaTime);

            if (transform.position == _targetPosition.position)
            {
                _targetPosition.position = _startPosition;
                _startPosition = transform.position;

                if (_direction.flipX)
                    _direction.flipX = false;
                else
                    _direction.flipX = true;
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