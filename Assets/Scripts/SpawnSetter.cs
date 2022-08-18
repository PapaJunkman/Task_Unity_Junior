using System.Collections;
using UnityEngine;

public class SpawnSetter : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _spawners;

    private float _spawnTime = 2f;
    
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_spawnTime);

        foreach (var spawner in _spawners)
        {
            Instantiate(_enemy, spawner.position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
