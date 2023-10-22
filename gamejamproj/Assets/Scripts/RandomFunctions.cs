using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFunctions : MonoBehaviour
{
    public GameObject goatPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGoat()
    {
        GameObject newGoat = Object.Instantiate(goatPrefab, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
    }
}
