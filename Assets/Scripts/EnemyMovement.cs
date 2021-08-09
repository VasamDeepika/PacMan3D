using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlayAudio("PlayerDeath");
            StartCoroutine(ChangeAfter2Seconds());
        }
    }
    IEnumerator ChangeAfter2Seconds()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("05_EndScene");
    }
}
