using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public string triggerName = "Trigger";

    [SerializeField]
    private bool disableOnActivate = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            MapManager.instance.OnTriggerHit(triggerName);

            if (disableOnActivate == true)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }

}
