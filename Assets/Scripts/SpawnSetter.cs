using System.Collections;
using UnityEngine;

public class SpawnSetter : MonoBehaviour
{
    private float _spawnTime = 2f;
    private Spawner[] _spawners;

    private void Start()
    {
        _spawners = gameObject.GetComponentsInChildren<Spawner>();

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        foreach (var spawner in _spawners)
        {
            spawner.SpawnEnemy();

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
