using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController charController = null;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float runMultiplier = 10;


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


        if (Input.GetKey(KeyCode.W))
        {
            charController.Move(transform.forward * speed * Time.deltaTime);
            firstTimeMoving = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            charController.Move(-transform.forward * speed * Time.deltaTime);
            firstTimeMoving = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            charController.Move(transform.right * speed * Time.deltaTime);
            firstTimeMoving = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            charController.Move(-transform.right * speed * Time.deltaTime);
            firstTimeMoving = false;
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
