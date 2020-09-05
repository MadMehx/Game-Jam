using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private string keyName = "Key";

    [SerializeField]
    private string fluffName = "Fluff Key";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            PlayerKeyManager.instance.GetKey(keyName);
            AlertTextManager.instance.MakeAlert($"{fluffName} acquired");
            Destroy(gameObject);
        }
    }


}
