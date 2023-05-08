using UnityEngine;

public class PlataformMoveFromRight : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento

    private Vector3 initialPosition; // Posici�n inicial del objeto
    private bool movingRight = true; // Indica si el objeto se est� moviendo hacia la derecha o hacia la izquierda

    void Start()
    {
        initialPosition = transform.position; // Guardamos la posici�n inicial del objeto
    }

    void Update()
    {
        // Si el objeto se est� moviendo hacia la derecha
        if (movingRight)
        {
            // Si todav�a no lleg� al punto final (X=420)
            if (transform.position.x > 420f)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime); // Movemos el objeto hacia la izquierda
            }
            // Si lleg� al punto final, cambiamos de direcci�n
            else
            {
                movingRight = false;
            }
        }
        // Si el objeto se est� moviendo hacia la izquierda
        else
        {
            // Si todav�a no lleg� al punto inicial (X=520)
            if (transform.position.x < 520f)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime); // Movemos el objeto hacia la derecha
            }
            // Si lleg� al punto inicial, cambiamos de direcci�n
            else
            {
                movingRight = true;
            }
        }
    }
}
