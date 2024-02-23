using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Bee : MonoBehaviour
{
    [SerializeField] private float timeDelayAttack;
    [SerializeField] private float offSet;
    [SerializeField] private float attackDistance;
    [SerializeField] private Transform attackPos;
    [SerializeField] private bool canAttack;
    [SerializeField] private GameObject bullet;

    [SerializeField] private float distance;
    Animator animator;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        Vector3 targerPos = GameManager.Instance.GetPlayerPosition();
        agent.SetDestination(new Vector3(targerPos.x, targerPos.y + offSet, targerPos.z));
        distance = (targerPos - transform.position).magnitude;
        if (distance <= attackDistance && canAttack == false)
        {
            canAttack = true;
            StartCoroutine("Attack");
        }
        if(distance > attackDistance) canAttack = false;
    }
    IEnumerator Attack()
    {
        while(canAttack == true)
        {
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(timeDelayAttack);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        animator.SetTrigger("die");
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    public void SpawnBullet()
    {
        var bul = Instantiate(bullet, attackPos.position, Quaternion.identity);
        Vector2 dir = (GameManager.Instance.GetPlayerPosition() - transform.position).normalized;
        bul.GetComponent<Rigidbody2D>().AddForce(dir * 5f, ForceMode2D.Impulse);
    }
}
