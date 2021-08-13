using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelController", menuName = "ScriptableObjects/LevelController")]
public class LevelController : ScriptableObject
{
    [SerializeField] private int mainSceneIndex = 0;
    [SerializeField] private bool showConsoleMessage = true;

    public void loadNextLevel()
    {
        resumeGame();
        int numberOfLevel = SceneManager.GetActiveScene().buildIndex;// get current level index
        if (showConsoleMessage) Debug.Log($"Load level index: {numberOfLevel + 1}");

        if (numberOfLevel < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(++numberOfLevel);// загрузка след уровня номер можно посмотреть через shift + ctrl + b
        else if (showConsoleMessage) Debug.LogWarning($"Can't load next level. Level is last!");
    }

    public void reStartLevel()
    {
        resumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (showConsoleMessage) Debug.Log($"Level reloaded!");
    }

    public void loadLevel(int numLevel)
    {
        resumeGame();
        Debug.Log($"Load level index: {numLevel}");
        if (numLevel < SceneManager.sceneCountInBuildSettings - 1 && numLevel >= 0)
            SceneManager.LoadScene(numLevel);
        else if (showConsoleMessage) Debug.LogWarning($"Can't load level. Incorrect number of Level!");
    }

    public void exitGame()
    {
        resumeGame();
        Application.Quit();
        if (showConsoleMessage) Debug.Log("Quit the Game.");
    }
    public void loadMainMenu()
    {
        resumeGame();
        SceneManager.LoadScene(mainSceneIndex);
        if (showConsoleMessage) Debug.Log($"Load MainMenu scene index: {mainSceneIndex}.");
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        if (showConsoleMessage) Debug.Log($"Game paused.");
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        if (showConsoleMessage) Debug.Log($"Game continue.");
    }
}