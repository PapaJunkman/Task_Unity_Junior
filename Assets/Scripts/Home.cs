using UnityEngine;

public class Home : MonoBehaviour
{
    private Alarm _alarm;

    private void Start()
    {
        _alarm = gameObject.GetComponentInChildren<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ThiefMover>(out ThiefMover thef))
        {
            _alarm.TurnOnAlarm();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefMover>(out ThiefMover thef))
        {
            _alarm.TurnOffAlarm();
        }
    }
}