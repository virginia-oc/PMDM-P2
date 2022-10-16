/*
 * This class manages the finish of levels.
 * @author Virginia Ojeda Corona
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                FindObjectOfType<Bola>().SendMessage("ChoqueSalida");
                Menu.LaunchLevel2();
            }
            else
            {
                FindObjectOfType<Bola>().SendMessage("ChoqueSalida");
                Menu.LaunchFinishScene();
            }
        }
    }
}
