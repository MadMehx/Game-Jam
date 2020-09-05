using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string mainMenuSceneName = "MainMenu";

    [SerializeField]
    public CharacterController charController = null;

    [SerializeField]
    private bool canMove = true;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float runMultiplier = 10;

    [SerializeField, ReadOnlyField]
    private Vector3 inputDirection;


    [SerializeField]
    private FootstepManager footManager = null;

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

    [Space(10)]
    [SerializeField]
    private Light playerPointLight = null;
    [SerializeField]
    private Light room1Light = null;

    [SerializeField]
    private float fadeTime = 3.0f;

    private bool showPrompts = false;


    [SerializeField]
    private GameObject moveUI = null;

    [SerializeField]
    private GameObject turnUI = null;

    void Start()
    {
        StartCoroutine(StartFade());
    }

    void Update()
    {
        if (showPrompts == true)
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

        if (inputDirection != Vector3.zero && canMove == true)
        {
            charController.Move(inputDirection.normalized * speed * Time.deltaTime);
            timeFoot += Time.deltaTime;
        }

        if (timeFoot >= timeBetweenFootSteps)
        {
            footManager.PlayFootstep();
            timeFoot = 0;
        }

        if (canMove == true)
        {
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



    }
    private IEnumerator StartFade()
    {
        float time = 0.0f;
        float startInt = playerPointLight.intensity;
        playerPointLight.intensity = 0;
        showPrompts = false;
        while (time <= fadeTime)
        {
            time += Time.deltaTime;
            playerPointLight.intensity = Mathf.Lerp(0.0f, startInt, time / fadeTime);
            yield return new WaitForEndOfFrame();
        }

        showPrompts = true;
        playerPointLight.intensity = startInt;
    }

    public IEnumerator EndGame()
    {
        float time = 0.0f;
        float startInt = playerPointLight.intensity;
        float startInt1 = room1Light.intensity;

        canMove = false;
        showPrompts = false;
        while (time <= fadeTime)
        {
            time += Time.deltaTime;
            playerPointLight.intensity = Mathf.Lerp(startInt, 0.0f, time / fadeTime);
            room1Light.intensity = Mathf.Lerp(startInt1, 0.0f, time / fadeTime);
            yield return new WaitForEndOfFrame();
        }

        showPrompts = true;
        playerPointLight.intensity = 0.0f;
        room1Light.intensity = 0.0f;

        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 6);
    }
}
