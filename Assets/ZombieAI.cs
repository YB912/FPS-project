using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _zombieSpeed;
    [SerializeField] private float _attackDestance;
    private Animator _zombieAnim;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("PlayerFeet");
        _zombieAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    public void ChasePlayer()
    {
        if (_player != null)
        {
            // Calculate the new position towards the player
            Vector3 targetPosition = Vector3.MoveTowards(transform.position, _player.transform.position, _zombieSpeed * Time.deltaTime);

            // Update the zombie's position
            transform.position = targetPosition;

            // Make the zombie look at the player
            transform.LookAt(_player.transform.position);
            _zombieAnim.SetBool("Running", true);
            ZombieAttack();
        }
    }

    public void ZombieAttack()
    {
        if(_player != null && Vector3.Distance(this.transform.position, _player.transform.position) < _attackDestance)
        {
            _zombieAnim.SetBool("Attaking", true) ;
        }
    }

}
