using UnityEditor;
using UnityEngine;

public class EscapePanel : MonoBehaviour
{
    public GameObject escapePanel;
    public GameObject optionsPanel;
    public static bool isPaused = false;

    private void Update()
    {
        HandlePauseInput();
    }

    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Inventory.isInventoryOpen)
        {
            if (optionsPanel.activeInHierarchy)
            {
                optionsPanel.SetActive(false);
                ResumeGame();
            }
            else if (escapePanel.activeInHierarchy)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        escapePanel.SetActive(true);
        isPaused = true;

        Cursor.visible = true; // Optionally, make the cursor visible when paused
    }

    private void ResumeGame()
    {
        
        escapePanel.SetActive(false);
        isPaused = false;

        Cursor.visible = false; // Optionally, hide the cursor when resuming
        if (Player.gameOver != true)
        {
            Time.timeScale = 1;
            
        }
    }

    public void ChooseEscape(string choice)
    {
        if (choice == "quit")
        {
            EditorApplication.ExitPlaymode();
        }
        else if (choice == "resume")
        {
            ResumeGame();
        }
        else if (choice == "options")
        {
            optionsPanel.SetActive(true);
            escapePanel.SetActive(false); // Close the pause menu when opening the options panel
        }
        else
        {
            Debug.Log("Invalid choice: " + choice);
        }
    }
}