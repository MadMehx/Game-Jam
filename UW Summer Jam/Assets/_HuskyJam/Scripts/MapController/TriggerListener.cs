using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public string triggerName = "Trigger";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            MapManager.instance.OnTriggerHit(triggerName);
            gameObject.SetActive(false);
        }
    }

}
