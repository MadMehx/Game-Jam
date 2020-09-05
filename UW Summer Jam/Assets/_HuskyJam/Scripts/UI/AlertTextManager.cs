using System.Collections.Generic;
using UnityEngine;

public class AlertTextManager : MonoBehaviour
{
    public static AlertTextManager instance = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI alertText = null;

    [SerializeField]
    private float textDuration = 3.0f;

    private List<string> textQueue = new List<string>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        textQueue = new List<string>();
    }

    private float time = 0.0f;
    private void Update()
    {
        if (textQueue.Count != 0) //This is also garbage code but its okay
        {
            alertText.text = textQueue[0];

            time += Time.deltaTime;

            if (time > textDuration)
            {
                time = 0.0f;
                textQueue.RemoveAt(0);
                alertText.text = "";
            }
        }
    }


    public void MakeAlert(string text)
    {
        if (textQueue.Contains(text) == false)
        {
            textQueue.Add(text);
        }
    }



}
