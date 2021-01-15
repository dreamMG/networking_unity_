using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] CharacterController controller = null;

    Vector3 movement;

    public override void OnStartAuthority()
    {
        enabled = true;
        FindObjectOfType<CameraController>().Target = transform;
    }

    [ClientCallback]
    private void Update() => Move();

    [Client]
    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("Ground"))
                    movement = hit.point;
            }
        }

        controller.Move((movement - transform.position) * moveSpeed * Time.deltaTime);
    }
}
