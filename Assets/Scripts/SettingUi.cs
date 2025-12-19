using UnityEngine;
using UnityEngine.UIElements;

public class SettingUi : MonoBehaviour
{
    VisualElement root;

    RadioButtonGroup fpsGroup;
    RadioButtonGroup graphicGroup;
    RadioButtonGroup audioGroup;
    Slider uiSlider;
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        root = GetComponent<UIDocument>().rootVisualElement;

        fpsGroup = root.Q<RadioButtonGroup>("FPS");
        graphicGroup = root.Q<RadioButtonGroup>("Graphic");
        audioGroup = root.Q<RadioButtonGroup>("Audio");
        uiSlider = root.Q<Slider>("UISize");
    

        LoadSettings();
        RegisterEvents();
    }

    void RegisterEvents()
    {
        fpsGroup.RegisterValueChangedCallback(e =>
        {
            Application.targetFrameRate = e.newValue == 0 ? 30 : 60;
            PlayerPrefs.SetInt("FPS", e.newValue);
        });

        graphicGroup.RegisterValueChangedCallback(e =>
        {
            QualitySettings.SetQualityLevel(e.newValue);
            PlayerPrefs.SetInt("Graphic", e.newValue);
        });

        audioGroup.RegisterValueChangedCallback(e =>
        {
            AudioListener.pause = e.newValue == 1;
            PlayerPrefs.SetInt("Audio", e.newValue);
        });

        uiSlider.RegisterValueChangedCallback(e =>
        {
            PlayerPrefs.SetFloat("UISize", e.newValue);
        });
       
    }

    void LoadSettings()
    {
        fpsGroup.value = PlayerPrefs.GetInt("FPS", 1);
        graphicGroup.value = PlayerPrefs.GetInt("Graphic", 1);
        audioGroup.value = PlayerPrefs.GetInt("Audio", 0);
        uiSlider.value = PlayerPrefs.GetFloat("UISize", 1f);

        Application.targetFrameRate = fpsGroup.value == 0 ? 30 : 60;
        QualitySettings.SetQualityLevel(graphicGroup.value);
        AudioListener.pause = audioGroup.value == 1;
    }
}
