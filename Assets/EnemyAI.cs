using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(MoveTowardsPlayer());
    }

    IEnumerator MoveTowardsPlayer()
    {
        while (true)
        {
            if (!isMoving)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                targetPosition = transform.position + direction;
                StartCoroutine(MoveToPosition(targetPosition));
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator MoveToPosition(Vector3 position)
    {
        isMoving = true;
        while ((position - transform.position).magnitude > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = position;
        isMoving = false;
    }
}
