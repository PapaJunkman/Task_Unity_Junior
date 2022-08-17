using UnityEngine;

public class Home : MonoBehaviour
{
    private Alarm _alarm;
    private bool _isEntered;

    private void Start()
    {
        _alarm = gameObject.GetComponentInChildren<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ThiefMover>(out ThiefMover thief))
        {
            _isEntered = true;

            _alarm.SetAlarmStat(_isEntered);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefMover>(out ThiefMover thief))
        {
            _isEntered = false;

            _alarm.SetAlarmStat(_isEntered);
        }
    }
}