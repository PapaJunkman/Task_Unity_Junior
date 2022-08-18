using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    public void SpawnEnemy()
    {
        Instantiate(_enemy, gameObject.transform.position, Quaternion.identity);
    }
}
