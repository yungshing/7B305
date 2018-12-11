using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnterMainScene : MonoBehaviour
{
    public string sceneName = "Main";
    public Slider slider;
    public Text text;

    private void Start()
    {
        slider.value = 0;
        slider.maxValue = 1;
        text.text = "";

        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        var v = SceneManager.LoadSceneAsync(sceneName);
        v.allowSceneActivation = false;
        while(!v.isDone && v.progress < 0.9f)
        {
            slider.value = v.progress;
            text.text = v.progress.ToString("p") + "%";
            yield return v.isDone;
        }
        while(slider .value<1)
        {
            slider.value += Time.deltaTime;
            text.text = slider.value.ToString("p") + "%";
            yield return null;
        }
        v.allowSceneActivation = true;

    }
}
