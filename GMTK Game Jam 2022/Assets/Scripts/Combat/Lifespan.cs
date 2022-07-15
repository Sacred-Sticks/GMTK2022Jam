using UnityEngine;

public class Lifespan : MonoBehaviour
{
    [SerializeField] private float seconds = 1;

    void Update()
    {
        seconds -= Time.deltaTime;
        if(seconds <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
