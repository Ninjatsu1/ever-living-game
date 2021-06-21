using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 2f;
    public Vector3 RandomizePlace = new Vector3(0.5f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition += new Vector3(Random.Range(-RandomizePlace.x, RandomizePlace.x),
            Random.Range(RandomizePlace.y, RandomizePlace.y), 0);
        
        Destroy(gameObject, DestroyTime);
    }
}
