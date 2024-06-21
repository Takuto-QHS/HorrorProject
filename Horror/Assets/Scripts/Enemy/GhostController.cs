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
    private Transform player;           //�ǂ�������Ώ�

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.position);       // player�Ɍ������Ĉړ�
    }

    /// <summary>
    /// OnCollider���ƃV�[���ړ��Ɏ��Ԃ��|�����ď����G���~�܂��
    /// OnTrigger�ɕύX
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
