using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyManager : MonoBehaviour
{
    public static PlayerKeyManager instance = null;

    public List<string> KeysOwned = new List<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        KeysOwned = new List<string>();
    }

    public void GetKey(string keyName)
    {
        if (KeysOwned.Contains(keyName) == true)
        {
            Debug.LogError("Duplicate Key Detected");
        }
        else
        {
            KeysOwned.Add(keyName);
        }
    }

    public bool CheckKey(string keyName)
    {
        if (KeysOwned.Contains(keyName) == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
