using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private string keyName = "Key";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            PlayerKeyManager.instance.GetKey(keyName);
            Destroy(gameObject);
        }
    }


}
