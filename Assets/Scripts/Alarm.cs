using UnityEngine;

public class Alarm : MonoBehaviour
{
    private Animator _animator;
    private AudioSource[] _audioSources;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSources = GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (_audioSources[0].isPlaying && _audioSources[1].volume < 1)
        {
            _audioSources[1].volume += Time.deltaTime;
        }

        if (_audioSources[0].isPlaying == false && _audioSources[1].volume > 0)
        {
            _audioSources[1].volume -= Time.deltaTime;

            if (_audioSources[1].isPlaying && _audioSources[1].volume <= 0)
            {
                _audioSources[1].Stop();
            }
        }
    }

    public void TurnOnAlarm()
    {
        _animator.SetBool("Alarm", true);

        foreach (var audioSorce in _audioSources)
        {
            audioSorce.Play();
        }
    }

    public void TurnOffAlarm()
    {
        _animator.SetBool("Alarm", false);

        _audioSources[0].Stop();
    }
}