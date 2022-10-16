/*
 * This class manages the behaviour of the ball. 
 * @author Virginia Ojeda Corona
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    [SerializeField] float velocidadAvance = 600f;
    private float velocidadRotac = 200f;
    private float xInicial, yInicial, zInicial;
    private int vidas = 3;
    private Quaternion rotInicial;
    public AudioSource reproductor;
    public AudioClip[] audios;
    [SerializeField] TMPro.TextMeshProUGUI HUD;

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        zInicial = transform.position.z;
        rotInicial = transform.rotation;
        reproductor = this.GetComponent<AudioSource>();
        HUD.text = SceneManager.GetActiveScene().name + "\n" + 
            "Vidas restantes: " + vidas;
    }

    // Update is called once per frame
    void Update()
    {
        float avance = Input.GetAxis("Vertical") * velocidadAvance * Time.deltaTime;
        float rotacion = Input.GetAxis("Horizontal") * velocidadRotac * Time.deltaTime;

        transform.Rotate(Vector3.up, rotacion);
        transform.position += transform.forward * Time.deltaTime * avance;

        HUD.text = SceneManager.GetActiveScene().name + "\n" +
           "Vidas restantes: " + vidas;
    }

    public void PerderVida()
    {
        ChoqueEnemigo();
        ResetPosition();
        vidas--;

        if (vidas == 0)
        {
            Menu.LaunchGameOverScene();
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(xInicial, yInicial, zInicial);
        transform.rotation = rotInicial;
    }

    public void ChoqueSalida()
    {
        reproductor.clip = audios[1];
        reproductor.Play();
    }

    public void ChoqueEnemigo()
    {
        reproductor.clip = audios[0];
        reproductor.Play();
    }
}
