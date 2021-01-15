using Mirror;
using System;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    private Transform target;
    public Transform Target { set => target = value; }
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private float speedFollow = 4f;

    [Client]
    private void LateUpdate() => FollowTarget();

    private void FollowTarget()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speedFollow * Time.deltaTime);
    }
}
