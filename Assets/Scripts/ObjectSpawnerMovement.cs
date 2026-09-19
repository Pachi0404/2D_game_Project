using UnityEngine;

public class ObjectSpawnerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float frequency = 1f;
    
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        MoveWithCosine();
    }

    void MoveWithCosine()
    {
        float xOffset = movementSpeed * Mathf.Cos(Time.time * frequency);
    
        transform.position = new Vector3(startPosition.x + xOffset, startPosition.y, startPosition.z);
    }
    
}
