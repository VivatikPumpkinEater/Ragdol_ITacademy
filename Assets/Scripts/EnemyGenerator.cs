using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPref = null;

    [SerializeField] private Vector2 _spawnPoint;
    [SerializeField] private float _createPeriod = 2f;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > _createPeriod)
        {
            Instantiate(_enemyPref, transform.position + new Vector3(Random.Range(-_spawnPoint.x, _spawnPoint.x), 0, Random.Range(-_spawnPoint.y, _spawnPoint.y)), Quaternion.identity);
            _time = 0f;
        }
    }
}
