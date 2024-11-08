using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPCWanderAndChase : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;
    public float detectionRadius = 15f;
    public string playerTag = "Player";
    public string sceneToLoad = "NextScene";

    private NavMeshAgent agent;
    private float timer;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        DetectAndChasePlayers();
    }

    void DetectAndChasePlayers()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(playerTag))
            {
                agent.SetDestination(hitCollider.transform.position);
                if (Vector3.Distance(transform.position, hitCollider.transform.position) < 1.5f)
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}
