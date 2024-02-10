using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnCollision : MonoBehaviour
{
    // Asume que este script está adjunto al jugador

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que se colisionó tiene la etiqueta "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reinicia el nivel actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
