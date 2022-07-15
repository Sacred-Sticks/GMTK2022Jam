using UnityEngine;

public class FollowWithOffset : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    
    void Update()
    {
        transform.position = target.position + offset;
    }
}
