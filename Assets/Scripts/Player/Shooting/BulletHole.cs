
using UnityEngine;

public class BulletHole : MonoBehaviour
{
    [SerializeField] private float _lifeSpan = 20f;

    private float _timer;

    private void OnEnable()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifeSpan)
        {
            ObjectPoolManager.instance.ReturnToPool(gameObject);
        }
    }
}
