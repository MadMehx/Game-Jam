using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController charController = null;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private bool isSmooth = true;

    [SerializeField]
    private float lookSpeed = 90;

    [SerializeField]
    private float lookSnap = 15;


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

        if (isSmooth == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, lookSnap);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, -lookSnap);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, lookSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, -lookSpeed * Time.deltaTime);
            }
        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 6);
    }
}
