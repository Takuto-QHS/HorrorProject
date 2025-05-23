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
    private Transform player;           //追いかける対象

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.position);       // playerに向かって移動
    }

    /// <summary>
    /// OnColliderだとシーン移動に時間が掛かって少し敵が止まる為
    /// OnTriggerに変更
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagName)
        {
            GameOver.buckSceneName = SceneManager.GetActiveScene().name;
            GameManager.ChangeSceneAsync(gameOverSceneName);
        }
    }
}
