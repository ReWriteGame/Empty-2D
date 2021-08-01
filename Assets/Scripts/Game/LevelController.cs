using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelController", menuName = "ScriptableObjects/LevelController")]
public class LevelController : ScriptableObject
{
    [SerializeField] private int mainSceneIndex = 0;
    public void loadNextLevel()
    {
        int numberOfLevel = SceneManager.GetActiveScene().buildIndex;// get current level index
        Debug.Log($"Load level index:{numberOfLevel + 1}");

        if (numberOfLevel < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(++numberOfLevel);// загрузка след уровня номер можно посмотреть через shift + ctrl + b
        else Debug.Log($"Can't load next level. Level is last!");
    }

    public void reStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log($"Level reloaded!");
    }

    public void loadLevel(int numLevel)
    {
        Debug.Log($"Load level index:{numLevel}");
        if (numLevel < SceneManager.sceneCountInBuildSettings - 1 && numLevel >= 0)
            SceneManager.LoadScene(numLevel);
        else Debug.Log($"Can't load level. Incorrect number of Level!");
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Quit the Game.");
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene(mainSceneIndex);
        Debug.Log($"Load MainMenu scene index {mainSceneIndex}.");
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        Debug.Log($"Game paused.");
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        Debug.Log($"Game continue.");
    }
}