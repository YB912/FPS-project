
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] private float _duration;

    private float _timer;

    private ParticleSystem _particleSystem;
    private Light _light;

    private void Start()
    {
        _timer = _duration;

        _particleSystem = GetComponent<ParticleSystem>();
        _light = GetComponent<Light>();

        _light.enabled = false;

        PlayerShootingHandler.OnShoot += OnShoot;
    }

    private void Update()
    {
        if (_timer >= _duration)
        {
            _light.enabled = false;
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void OnShoot()
    {
        _particleSystem.Play();
        _light.enabled = true;
        _timer = 0;
    }
}
