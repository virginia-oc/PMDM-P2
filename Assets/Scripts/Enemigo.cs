/*
 * This class manages the behaviour of the enemies.
 * @author Virginia Ojeda Corona
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    private Vector3 siguientePosicion;
    private float velocidad = 2;
    private float distanciaCambio = 0.1f;
    private sbyte numeroSiguientePosicion = 0;
    private sbyte direccion = -1;

    // Start is called before the first frame update
    void Start()
    {
        siguientePosicion = wayPoints[0].position;

        if (SceneManager.GetActiveScene().name == "Level2")     
            IncrementarVelocidad();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            siguientePosicion,
            velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, siguientePosicion) < distanciaCambio)
        {
            if (numeroSiguientePosicion - 1 < 0 || 
                numeroSiguientePosicion + 1 >= wayPoints.Length)
                direccion *= -1;

            numeroSiguientePosicion += direccion;
            siguientePosicion = wayPoints[numeroSiguientePosicion].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage("PerderVida");
    }

    public void IncrementarVelocidad()
    {
        velocidad += 3f;
    }
}
