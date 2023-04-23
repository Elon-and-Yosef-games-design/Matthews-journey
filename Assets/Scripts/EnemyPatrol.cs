using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{   
    [SerializeField]
    public float speed = 2f;
    [SerializeField]
    public float startPoint = 0f;
    [SerializeField]
    public float endPoint = 10f;
    [SerializeField]
    private Vector3 targetPosition;
    private bool moveRight = true;
    private float epsilon = 0.1f;

    void Start()
    {
        targetPosition = new Vector3(startPoint, transform.position.y, transform.position.z);
    }

    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - startPoint) < epsilon && !moveRight)
        {
            moveRight = true;
            targetPosition = new Vector3(transform.position.x + endPoint, transform.position.y, transform.position.z);
        }
        else if (Mathf.Abs(transform.position.x - endPoint) < epsilon && moveRight)
        {
            moveRight = false;
            targetPosition = new Vector3(transform.position.x +  startPoint, transform.position.y, transform.position.z);
        }
    }
}
