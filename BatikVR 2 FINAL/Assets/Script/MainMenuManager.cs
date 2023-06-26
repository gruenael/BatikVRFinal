using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject gameModePanel;
    public GameObject ngebatikDifficultyPanel;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        gameModePanel.SetActive(false);
        ngebatikDifficultyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        mainPanel.SetActive(false);
        gameModePanel.SetActive(true);
    }

    public void BackGameModeButton()
    {
        gameModePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void SinauButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NgebatikButton()
    {
        gameModePanel.SetActive(false);
        ngebatikDifficultyPanel.SetActive(true);
    }

    public void BackNgebatikDifficultyButton()
    {
        ngebatikDifficultyPanel.SetActive(false);
        gameModePanel.SetActive(true);
    }

    public void SettingsButton()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

}
