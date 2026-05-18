using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int healAmount;
    public bool isFullHeal;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isFullHeal)
            {
                HealthManager.instance.ResetHealth();
            }else{
                HealthManager.instance.AddHealth(healAmount);
            }
            Destroy(gameObject);
        }
    }
}
