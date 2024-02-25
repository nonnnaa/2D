using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    public enum audio
    {
        jump,
        die,
        hit,
        collector
    }
    // Start is called before the first frame update
    [SerializeField] List<AudioClip> clips = new List<AudioClip>();
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
        if(Input.GetKeyDown(KeyCode.A))
        {
            AudioSource.PlayClipAtPoint(clips[(int)audio.hit], Camera.main.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioSource.PlayClipAtPoint(clips[(int)audio.die], Camera.main.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(clips[(int)audio.jump], Camera.main.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            AudioSource.PlayClipAtPoint(clips[(int)audio.collector], Camera.main.transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            gameObject.SetActive(false);
        }
    }
}
