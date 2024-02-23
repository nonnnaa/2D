using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    [SerializeField] private Transform player;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            gameObject.SetActive(false);
        }
    }
}
