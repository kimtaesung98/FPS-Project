using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;

    int enemiesLeft = 0;

    const string ENEMIES_LEFT_STRING ="Enemeies Left: ";
    public void AdjustenemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();


        if (enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
        }
    }

    public void RestartGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
