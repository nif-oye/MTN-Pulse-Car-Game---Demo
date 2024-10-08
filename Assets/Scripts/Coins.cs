using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioSource coinReceived;
    public float hoverAmplitude = 0.5f; 
    public float hoverFrequency = 1f; 
    private float startY; 


    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, 180 * Time.deltaTime);
        HoverEffect();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.isGameActive)
        {
            Debug.Log("Player entered the trigger.");
            coinReceived.Play();

            GameManager.instance.AddScore(1);

            Destroy(gameObject);
        }
    }

    void HoverEffect()
    {
        float newY = startY + Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
