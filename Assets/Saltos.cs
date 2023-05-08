using UnityEngine;
using UnityEngine.SceneManagement;

public class Saltos : MonoBehaviour
{
    private Movimiento contadorSaltos;

    // Start is called before the first frame update
    void Start()
    {
        contadorSaltos = FindObjectOfType<Movimiento>();
    }

    // ...

    // M�todo para detectar cuando se ha perdido el juego
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pozo")
        {
            // Llamar al m�todo para actualizar el texto antes de cambiar de escena
            contadorSaltos.ActualizarTexto();
            SceneManager.LoadScene("EscenaResultados");
        }
    }

    // M�todo para detectar cuando se realiza un salto
     void Saltar()
    {
        // Incrementar el contador de saltos
        contadorSaltos.IncrementarSaltos();
        // ...
    }
}
