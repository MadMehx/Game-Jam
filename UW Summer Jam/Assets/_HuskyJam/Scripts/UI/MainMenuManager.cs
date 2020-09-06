using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas = null;

    [SerializeField]
    private Light pointLight = null;

    [SerializeField]
    private float fadeTime = 3;

    private float startInt;

    [SerializeField]
    private string sceneName = "GameScene";

    public void Start()
    {
        Cursor.visible = true;
    }

    public void StartGame()
    {
        StartCoroutine(StartFade());
    }

    private IEnumerator StartFade()
    {
        startInt = pointLight.intensity;

        canvas.SetActive(false);

        float time = 0.0f;
        while (time <= fadeTime)
        {
            time += Time.deltaTime;
            pointLight.intensity = Mathf.Lerp(startInt, 0.0f, time / fadeTime);
            yield return new WaitForEndOfFrame();
        }
        pointLight.intensity = 0;

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
