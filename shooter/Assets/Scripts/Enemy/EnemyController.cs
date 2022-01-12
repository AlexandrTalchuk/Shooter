using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _lookRadius;
    [SerializeField] private Transform _target;
    private NavMeshAgent NavMeshAgent;
    private float _distance;

    private void Start()
    {
        _target = GameManager.instance.player.transform;
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        _distance = Vector3.Distance(_target.position, transform.position);
        if (_distance <= _lookRadius)
        {
            NavMeshAgent.SetDestination(_target.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
    }
}
