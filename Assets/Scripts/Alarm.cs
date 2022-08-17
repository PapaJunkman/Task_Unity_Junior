using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _unitChangeVolume;

    private float _currentValueVolume;
    private Animator _animator;
    private AudioSource[] _audioSources;
    private Coroutine _changesVolume;

    private const string Entered = "Entered";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSources = GetComponents<AudioSource>();
    }

    private IEnumerator ChangesVolume(float value)
    {
        bool isWork = true;

        while (isWork)
        {
            _currentValueVolume = _audioSources[1].volume;
            _audioSources[1].volume += value;

            if (_audioSources[1].volume == _currentValueVolume)
                isWork = false;

            yield return null;
        }

        if (_audioSources[0].isPlaying == false)
            _audioSources[1].Stop();
    }

    public void SetAlarmState(bool isEntered)
    {
        _animator.SetBool(Entered, isEntered);

        if (_changesVolume != null)
            StopCoroutine(_changesVolume);

        if (isEntered)
        {
            foreach (var audioSorce in _audioSources)
            {
                audioSorce.Play();
            }

            _changesVolume = StartCoroutine(ChangesVolume(_unitChangeVolume));
        }
        else
        {
            _audioSources[0].Stop();

            _changesVolume = StartCoroutine(ChangesVolume(-_unitChangeVolume));
        }
    }
}