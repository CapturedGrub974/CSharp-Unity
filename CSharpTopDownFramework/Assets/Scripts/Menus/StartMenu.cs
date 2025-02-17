using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Canvas m_startMenu;
    public Canvas m_controlsMenu;
    public Canvas m_quitMenu;
    public Button m_startText;
    public Button m_controlsText;
    public Button m_exitText;

    // Use this for initialization
    void Start()
    {
        m_quitMenu = m_quitMenu.GetComponent<Canvas>();
        m_startText = m_startText.GetComponent<Button>();
        m_controlsText = m_controlsText.GetComponent<Button>();
        m_exitText = m_exitText.GetComponent<Button>();
        m_startMenu.enabled = true;
        m_controlsMenu.enabled = false;
        m_quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        m_quitMenu.enabled = true;
        m_startMenu.enabled = false;
    }

    public void Nopress()
    {
        m_quitMenu.enabled = false;
        m_startMenu.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        m_controlsMenu.enabled = true;
        m_startMenu.enabled = false;
    }

    public void Back()
    {
        m_controlsMenu.enabled = false;
        m_startMenu.enabled = true;
    }
}