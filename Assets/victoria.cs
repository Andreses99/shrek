using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoria : MonoBehaviour
{
    /*
   private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Final");

        }
    }
}
