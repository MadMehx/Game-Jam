using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance = null;

    [SerializeField]
    private List<GameObject> trigger1Enable = new List<GameObject>();
    [SerializeField]
    private List<GameObject> trigger1Disable = new List<GameObject>();


    void Start()
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
