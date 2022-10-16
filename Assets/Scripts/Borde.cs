/*
 * This class manages the behaviour of the level edges.
 * @author Virginia Ojeda Corona
 */

using UnityEngine;

public class Borde : MonoBehaviour
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
        FindObjectOfType<Bola>().SendMessage("PerderVida");
    }
}
