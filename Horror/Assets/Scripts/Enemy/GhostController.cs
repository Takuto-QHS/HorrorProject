using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    const string tagName = "Player";
    const string gameOverSceneName = "GameOver";

    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private Transform player;           //’Ç‚¢‚©‚¯‚é‘ÎÛ

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.position);       // player‚ÉŒü‚©‚Á‚ÄˆÚ“®
    }

    /// <summary>
    /// OnCollider‚¾‚ÆƒV[ƒ“ˆÚ“®‚ÉŠÔ‚ªŠ|‚©‚Á‚Ä­‚µ“G‚ª~‚Ü‚éˆ×
    /// OnTrigger‚É•ÏX
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagName)
        {
            GameOver.buckSceneName = SceneManager.GetActiveScene().name;
            GameManager.ChangeScene(gameOverSceneName);
        }
    }
}
