using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemy;

    private void Start()
    {
        StartCoroutine(CreateEnamy());
    }

    IEnumerator CreateEnamy()
    {
        while (true)
        {
            int idEnemy = Random.Range(0, _enemy.Count);
            Instantiate(_enemy[idEnemy], transform);
            yield return new WaitForSeconds(2.7f);
        }
    }
}
