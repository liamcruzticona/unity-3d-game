using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn(){
        StartCoroutine(RespawnWaiter());
    }
    public IEnumerator RespawnWaiter(){
        PlayerController.instance.gameObject.SetActive(false);
        CameraController.instance.cmBrain.enabled = false;
        UIManager.instance.fadeToBlack = true;

        Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f, 1f, 0f), PlayerController.instance.transform.rotation);

        yield return new WaitForSeconds(2f);
        UIManager.instance.fadeFromBlack = true;
        PlayerController.instance.transform.position = respawnPosition;
        CameraController.instance.cmBrain.enabled = true;
        PlayerController.instance.gameObject.SetActive(true);
        HealthManager.instance.ResetHealth();
    }
    public void SetSpawnPoint(Vector3 newSpawnPoint){
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn point set to: " + respawnPosition);
    }
}
