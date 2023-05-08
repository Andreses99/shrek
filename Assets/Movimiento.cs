using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security.Cryptography.X509Certificates;

public class Movimiento : MonoBehaviour
{
    [SerializeField] float velocidadMov = 13;
    [SerializeField] float gravedad = -25;
    [SerializeField] float fuerzaSalto = 20f;
    [SerializeField] float velCorrer = 30;

    CharacterController player;
    [SerializeField] private TMP_Text textoSaltos;

    Vector3 velocidadY;
    public Animator animator;
    private float gravity = -20f;
    public Transform tplayer;
    //saltar
    private bool canJump = true;  // Indica si el jugador puede saltar
    private int saltosRestantes = 1;
    private int saltos = 0;
    private bool saltando = true;
    private bool corriendo = false;
    private float velocidadActual;
    private int contador = 0;
    //correr
    bool hacerAlgo = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }
   
    // Update is called once per frame
    void Update()
    {


        if (player.isGrounded && velocidadY.y < 15)
        {
            velocidadY.y = -1;
        }
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * h + transform.forward * v + transform.up * 0;
        /*
        if (player.isGrounded && velocidadY.y > 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //velocidadMov = velCorrer;

            player.Move(move * velCorrer * Time.deltaTime);

            animator.SetBool("correr", true);
               
        }
        else
        {
            animator.SetBool("correr", false);
        }
        */
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            corriendo = true;
            velocidadActual = velocidadMov + velCorrer;
            animator.SetBool("correr", true);
            animator.SetBool("salte", false);


        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
        {
            corriendo = true;
            velocidadActual = velocidadMov+velCorrer;
            animator.SetBool("correr", true);
            animator.SetInteger("IdAnim", 2);
            animator.SetBool("salte", true);
        }
        // Detectar si el jugador soltó la tecla Shift para desactivar la carrera
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            corriendo = false;
            velocidadActual = velocidadMov;
            animator.SetBool("correr", false);
        }
        if (player.isGrounded)
        {

           /*
            while (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetBool("acostado", true);
                animator.SetBool("correr", false);
                animator.SetInteger("IdAdnim", 0);

                velocidadY.y = 0;
                hacerAlgo = false;
            }
            */
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetBool("acostado", true);
                animator.SetBool("correr", false);
                animator.SetInteger("IdAdnim", 0);
                fuerzaSalto = 0;
                velocidadMov=0;
                // hacerAlgo = false;
                player.Move(move * fuerzaSalto);
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                animator.SetBool("acostado", false);
                hacerAlgo = true;
                fuerzaSalto = 20f;
                velocidadMov = 13;
            }
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetBool("dancing", true);
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                animator.SetBool("dancing", false);
            }
            if (v == 0 && h == 0)
            {
                animator.SetInteger("IdAnim", 0);
            }
            else
            {
                /*
                if (v < 0)
                {
                    animator.SetFloat("movVertical", -1);
                }
                else
                {
                    animator.SetFloat("movVertical", 1);
                }*/


                animator.SetInteger("IdAnim", 1);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
               

                
                saltosRestantes = 1;
                velocidadY.y = Mathf.Sqrt(fuerzaSalto * -2 * gravity);
                animator.SetInteger("IdAnim", 2);
                canJump = false;

            }
        }

        else
        {
            animator.SetInteger("IdAnim", 3);
        }
        if (!player.isGrounded && saltosRestantes > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            velocidadY.y = Mathf.Sqrt(fuerzaSalto * -2 * gravity);
            saltosRestantes--;
        }
        float factorVelocidad = corriendo ? 5f : 1f;
        float nada = hacerAlgo ? 1 : 0;
        player.Move(move * velocidadMov * factorVelocidad * Time.deltaTime * nada);
        velocidadY.y += gravedad * Time.deltaTime * nada;
        player.Move(velocidadY * Time.deltaTime);
    }
    public void IncrementarSaltos()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            saltos++;
        }

    }
    public void ActualizarTexto()
    {
        textoSaltos.text = saltos.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pozo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y > 0.9)
        {
            canJump = true;  // El jugador puede saltar de nuevo
            saltando = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            contador++;
        }
    
    }
    
       
    
}