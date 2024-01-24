

using Unity.VisualScripting;
using UnityEngine;

public class ZombieInfo : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private float _zombieSpeed;

    [SerializeField] private float _attackDestance;
    [SerializeField] private Camera _cam;

    [SerializeField]private Animator _zombieAnim;

    public GameObject player { get => _player; private set => _player = GameObject.FindGameObjectWithTag("PlayerFeet"); }

    public float zombieSpeed { get => _zombieSpeed; }

    public Animator zombieAnim { get => _zombieAnim; private set => _zombieAnim = this.GetComponent<Animator>(); }

    public float attackDestance { get => _attackDestance; }

    public Camera cam { get => _cam; private set => _cam = _player.GetComponent<Camera>(); }


    public void LookAt(Vector3 pos)
    {
        transform.LookAt(pos);
    }
}
