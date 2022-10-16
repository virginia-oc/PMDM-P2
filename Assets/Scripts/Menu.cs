/*
 * This class manage loading scenes.
 * @author Virginia Ojeda 
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "FinishScene")
        {
            StartCoroutine(WaitForFinishScene(5.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public static void LaunchLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public static void LaunchLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public static void LaunchFinishScene()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public static void LaunchGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public static void LaunchWelcomeScene()
    {
        SceneManager.LoadScene("WelcomeScene");
    }

    private IEnumerator WaitForFinishScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        LaunchWelcomeScene();
    }
}
