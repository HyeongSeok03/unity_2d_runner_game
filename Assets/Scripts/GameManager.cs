using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }
    public Image[] lifeImgaes;
    public Player player;
    public int life;
    public bool isGameOver;

    public Vector2 recentCheckPointPos;

    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    void Start()
    {
        recentCheckPointPos = player.transform.position;
        UpdateLifeUI();
    }
    Vector2 playerPos;

    public void UpdateLifeUI()
    {
        for (int i = 0; i < lifeImgaes.Length; i++)
        {
            if (i < life)
            {
                lifeImgaes[i].gameObject.SetActive(true);
            }
            else
            {
                lifeImgaes[i].gameObject.SetActive(false);
            }
        }
    }

    public void Attacked()
    {
        life--;
        if (life <= 0)
        {
            GameOver();
            UpdateLifeUI();
            return;
        }
        player.transform.position = recentCheckPointPos;
        UpdateLifeUI();
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void GameClear()
    {
        isGameOver = true;
        gameClearPanel.SetActive(true);
        player.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
