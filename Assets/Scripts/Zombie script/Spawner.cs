
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawningTime = 10;
    [SerializeField] private int _maximumTotalZombies;
    [SerializeField] private int _maximumNewZombies;
    
    [SerializeField] private AnimationCurve _spawningAmountCurve;

    private int _cycleCount;
    private int _maximumCycleCount;
    private int _zombiesAlive;

    private Transform _playerTransform;
    private Transform _zombieHolder;

    public int zombiesAlive { get; set; }

    private void Start()
    {
        _maximumCycleCount = (int)_spawningAmountCurve.keys[_spawningAmountCurve.keys.Length - 1].value;
        _playerTransform = PlayerInfo.instance.transform;
        _zombieHolder = GameObject.Find("Zombie Holder").transform;
        InvokeRepeating("SpawnEnemy", 5f, _spawningTime);       
    }

    private void SpawnEnemy()
    {
        if (_maximumTotalZombies - _zombiesAlive > _spawningAmountCurve.Evaluate(_cycleCount))
        {
            if (_cycleCount < _maximumCycleCount) { _cycleCount++; }
            var zombieAmount = _cycleCount > _maximumCycleCount ? _maximumNewZombies : _spawningAmountCurve.Evaluate(_cycleCount);
            for (var i = 0; i < zombieAmount; i++)
            {
                var randomPoint = new Vector3(Random.Range(-15.5f, 16.5f), 0, Random.Range(-15.5f, 16.5f));
                var zombie = ObjectPoolManager.instance.TakeFromPool(_enemyPrefab, randomPoint, Quaternion.identity, _zombieHolder);
                zombie.transform.LookAt(new Vector3(_playerTransform.position.x, 0, _playerTransform.position.z));
                _zombiesAlive++;
            }
            AudioManager.instance.PlaySound(AudioManager.Type.SPAWNER, PlayerInfo.instance.GetComponent<AudioSource>(), 1);
        }
    }
}
