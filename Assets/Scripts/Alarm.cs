using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _bell;
    [SerializeField] private AudioSource _siren;

    private Animator _animator;
    private Coroutine _changesVolume;
    private float _minValueVolume = 0;
    private float _maxValueVolume = 1;
    private float _unitScale = 100;

    private const string Entered = "Entered";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private IEnumerator ChangesVolume(float targrtValue, float value)
    {
        bool isWork = true;

        while (isWork)
        {
            if (_siren.volume != targrtValue)
                _siren.volume += value;
            else
                isWork = false;

            yield return null;
        }

        if (_bell.isPlaying == false)
            _siren.Stop();
    }

    public void TurnOnAlarm()
    {
        _animator.SetBool(Entered, true);
        _bell.Play();
        _siren.Play();

        if (_changesVolume != null)
            StopCoroutine(_changesVolume);

        _changesVolume = StartCoroutine(ChangesVolume(_maxValueVolume, _maxValueVolume/_unitScale));
    }

    public void TurnOffAlarm()
    {
        _animator.SetBool(Entered, false);
        _bell.Stop();

        if (_changesVolume != null)
            StopCoroutine(_changesVolume);

        _changesVolume = StartCoroutine(ChangesVolume(_minValueVolume, -(_maxValueVolume / _unitScale)));
    }
}