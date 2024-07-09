using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                if (tile != null)
                {
                    StartCoroutine(MoveToPosition(hit.point));
                }
            }
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
