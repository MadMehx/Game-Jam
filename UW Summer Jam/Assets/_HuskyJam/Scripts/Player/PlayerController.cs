using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController charController = null;

    [SerializeField]
    private float speed = 1;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            charController.Move(transform.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            charController.Move(-transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            charController.Move(transform.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            charController.Move(-transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, 15);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -15);
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 6);
    }
}
