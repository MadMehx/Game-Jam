using UnityEngine;

public class VersionDisplay : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI text = null;
    void Start()
    {
        text.text = $"v{Application.version}";
    }
}
