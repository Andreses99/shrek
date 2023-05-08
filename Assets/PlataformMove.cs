using UnityEngine;

public class PlataformMoveFromRight : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento

    private Vector3 initialPosition; // Posición inicial del objeto
    private bool movingRight = true; // Indica si el objeto se está moviendo hacia la derecha o hacia la izquierda

    void Start()
    {
        initialPosition = transform.position; // Guardamos la posición inicial del objeto
    }

    void Update()
    {
        // Si el objeto se está moviendo hacia la derecha
        if (movingRight)
        {
            // Si todavía no llegó al punto final (X=420)
            if (transform.position.x > 420f)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime); // Movemos el objeto hacia la izquierda
            }
            // Si llegó al punto final, cambiamos de dirección
            else
            {
                movingRight = false;
            }
        }
        // Si el objeto se está moviendo hacia la izquierda
        else
        {
            // Si todavía no llegó al punto inicial (X=520)
            if (transform.position.x < 520f)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime); // Movemos el objeto hacia la derecha
            }
            // Si llegó al punto inicial, cambiamos de dirección
            else
            {
                movingRight = true;
            }
        }
    }
}
