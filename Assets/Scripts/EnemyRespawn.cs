using UnityEngine;

public class EnemyRespawnController : MonoBehaviour
{
    public GameObject enemyPrefab; // Asigna el prefab del enemigo en el inspector
    public Transform[] spawnPoints; // Asigna los puntos de reaparición en el inspector
    private int enemiesAlive = 0; // Contador de enemigos vivos

    void Start()
    {
        SpawnEnemies(); // Llama esto para spawnear enemigos al inicio
    }

    void Update()
    {
        // Aquí podrías tener lógica adicional, por ejemplo, verificar si los enemigos están vivos basado en otra lógica
    }

    public void EnemyDied()
    {
        enemiesAlive--; // Un enemigo murió, decrementar el contador
        Debug.Log("Enemy died. Enemies alive: " + enemiesAlive);
        if (enemiesAlive <= 0)
        {
            SpawnEnemies(); // Si todos los enemigos han muerto, reaparecerlos
        }
    }

    void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Debug.Log("Spawning enemy at " + spawnPoint.position);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); // Crea una instancia del prefab en cada punto de reaparición
            enemiesAlive++; // Incrementa el contador por cada enemigo creado
        }
        Debug.Log("Enemies alive: " + enemiesAlive);
    }
}