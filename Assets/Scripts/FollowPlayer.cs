using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform followTarget;
    [Space]
    [Space]
    public bool SmoothFollow = false;
    public float FollowSpeed;
    [Range(0, 10)] public float distanceLeniance;

    private void Start()
    {
        if (followTarget == null)
        {
            followTarget = FindAnyObjectByType<Entity>().transform;
        }
    }

    private void LateUpdate()
    {
        if (SmoothFollow) FollowSmooth();
        else
        {
            transform.position = followTarget.position;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

    private void FollowSmooth()
    {
        transform.position += (Vector2.Distance(transform.position, followTarget.position) - distanceLeniance)
            * FollowSpeed * Time.deltaTime * (followTarget.position - transform.position).normalized;
    }
}
