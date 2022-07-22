using UnityEngine.SceneManagement;
public enum SceneName
{
    Logo,
    Main,
    OutSide,
    GameMenu
}
public enum GameName
{
    Touch_Bell,
    CardGame,
    G_Runner
}

public class SceneService : Singleton<SceneService>
{
    public void LoadScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    public void LoadScene(GameName gamename)
    {
        SceneManager.LoadScene(gamename.ToString());
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
