using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController charController = null;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float runMultiplier = 10;

    [SerializeField, ReadOnlyField]
    private Vector3 inputDirection;


    [SerializeField]
    private FootstepManager footManager;

    [SerializeField]
    private float timeBetweenFootSteps = 1.0f;
    [SerializeField]
    private float timeFoot = 0.0f;


    [SerializeField]
    private bool isSmooth = true;

    [SerializeField]
    private float lookSpeed = 90;

    [SerializeField]
    private float lookSnap = 15;

    [SerializeField, ReadOnlyField]
    private bool firstTimeMoving = true;

    [SerializeField, ReadOnlyField]
    private bool firstTimeTurning = true;

    [SerializeField]
    private GameObject moveUI = null;

    [SerializeField]
    private GameObject turnUI = null;

    void Start()
    {

    }

    void Update()
    {
        if (firstTimeMoving == true) //Holy fuck this is literal garbage code
        {
            moveUI.SetActive(true);
        }
        else
        {
            moveUI.SetActive(false);
        }

        if (firstTimeMoving == false && firstTimeTurning == true)
        {
            turnUI.SetActive(true);
        }
        else
        {
            turnUI.SetActive(false);
        }


#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * runMultiplier;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / runMultiplier;
        }
#endif
        inputDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputDirection += transform.forward;
            firstTimeMoving = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputDirection += -transform.forward;
            firstTimeMoving = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputDirection += transform.right;
            firstTimeMoving = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputDirection += -transform.right;
            firstTimeMoving = false;
        }

        if (inputDirection != Vector3.zero)
        {
            charController.Move(inputDirection.normalized * speed * Time.deltaTime);
            timeFoot += Time.deltaTime;
        }

        if (timeFoot >= timeBetweenFootSteps)
        {
            footManager.PlayFootstep();
            timeFoot = 0;
        }

        if (isSmooth == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, lookSnap);
                firstTimeTurning = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, -lookSnap);
                firstTimeTurning = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, lookSpeed * Time.deltaTime);
                firstTimeTurning = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, -lookSpeed * Time.deltaTime);
                firstTimeTurning = false;
            }
        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 6);
    }
}
