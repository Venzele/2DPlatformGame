using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoints;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            Instantiate(_template, _spawnPoints.GetChild(i).position, Quaternion.identity);
        }
    }
}
