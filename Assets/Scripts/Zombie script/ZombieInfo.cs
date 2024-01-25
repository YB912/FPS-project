

using Unity.VisualScripting;
using UnityEngine;

public class ZombieInfo : MonoBehaviour
{
    [SerializeField] private float _zombieSpeed;

    [SerializeField] private float _attackDistance;
    [SerializeField] private Camera _cam;

    public float zombieSpeed { get => _zombieSpeed; }

    public float attackDistance { get => _attackDistance; }

    public Camera cam { get => _cam; }


    public void LookAt(Vector3 pos)
    {
        transform.LookAt(pos);
    }
}
