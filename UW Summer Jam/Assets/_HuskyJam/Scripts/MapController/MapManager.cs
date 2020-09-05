using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance = null;

    [SerializeField]
    private CharacterController playerController = null;

    [Header("Area 1")]
    [SerializeField]
    private List<GameObject> trigger1Enable = new List<GameObject>();
    [SerializeField]
    private List<GameObject> trigger1Disable = new List<GameObject>();


    [Header("Area 2")]
    [SerializeField]
    private float doorFadeLength = 2.0f;
    [SerializeField]
    private MeshRenderer door1MeshRenderer = null;
    [SerializeField]
    private Collider door1Collider = null;

    [Header("Area 3")]
    [SerializeField]
    private Transform endlessHallwayPoint1 = null;
    [SerializeField]
    private Transform endlessHallwayPoint2 = null;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {

    }



    public void OnTriggerHit(string triggerName, GameObject source)
    {
        Debug.Log($"Trigger hit {triggerName}");

        switch (triggerName)
        {
            case ("Trigger 1"):
                EnableDisableObjects(trigger1Enable, trigger1Disable);
                break;

            case ("EndlessTrigger 1"):
                playerController.enabled = false;
                playerController.transform.position = playerController.transform.position - (endlessHallwayPoint1.position - endlessHallwayPoint2.position);
                playerController.enabled = true;
                break;
            case ("EndlessTrigger 2"):
                playerController.enabled = false;
                playerController.transform.position = playerController.transform.position - (endlessHallwayPoint2.position - endlessHallwayPoint1.position);
                playerController.enabled = true;
                break;
            case ("Door Trigger 1"):
                if (PlayerKeyManager.instance.CheckKey("Door 1") == true)
                {
                    //Has Key
                    StartCoroutine(FadeDoor(door1Collider, door1MeshRenderer));
                    source.SetActive(false);
                }
                else
                {
                    //No Key
                    Debug.Log("No Key");
                }
                break;

        }
    }

    private void EnableDisableObjects(List<GameObject> enableList, List<GameObject> disableList)
    {
        foreach (GameObject go in enableList)
        {
            go.SetActive(true);
        }

        foreach (GameObject go in disableList)
        {
            go.SetActive(false);
        }
    }

    private IEnumerator FadeDoor(Collider doorCollider, MeshRenderer doorRenderer)
    {
        doorCollider.enabled = false;
        float time = 0.0f;

        while (time < doorFadeLength)
        {
            time += Time.deltaTime;
            doorRenderer.material.SetFloat("_AlphaFade", 1.0f - (time / doorFadeLength));
            yield return new WaitForEndOfFrame();
        }

        Destroy(door1Collider.gameObject);
    }



}
