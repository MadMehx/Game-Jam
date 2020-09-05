using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance = null;

    [SerializeField]
    private CharacterController playerController = null;

    [SerializeField]
    private List<GameObject> trigger1Enable = new List<GameObject>();
    [SerializeField]
    private List<GameObject> trigger1Disable = new List<GameObject>();

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



    public void OnTriggerHit(string triggerName)
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

}
