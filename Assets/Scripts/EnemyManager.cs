using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    private EnemyStatus enemyStatus;
    private float speed = 1.5f;
    private float distance;
    private int currentHP;
    private int damage;
    public string enemyName;

    // Start is called before the first frame update
    void Start()
    {
        agent.speed = speed;
        enemyName = GetComponent<EnemyInfo>().enemyName;
        enemyStatus = enemyStatusSO.enemyStatusList.FirstOrDefault(e => e.EnemyName == enemyName);
        currentHP = enemyStatus.HP;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if(distance < 10)
        {
            agent.destination = target.position;
            animator.SetBool("Found", true);
        }
        else
        {
            animator.SetBool("Found", false);
        }

        if (currentHP <= 0)
        {
            animator.SetBool("Dead", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            damage = CalculateDamage(playerStatusSO.Attack,enemyStatus.Defence);
            if (damage <= 0) return;
            currentHP -= (playerStatusSO.Attack - enemyStatus.Defence);
        }
    }

    private int CalculateDamage(int attackPoint, int defencePoint)
    {
        return (int)(attackPoint / 2 - defencePoint / 4);
    }
}
