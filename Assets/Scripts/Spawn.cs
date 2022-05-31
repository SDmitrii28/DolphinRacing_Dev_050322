using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] ob;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        while (true)
        {

            Instantiate(ob[Random.Range(0, ob.Length)], new Vector2(11, 0), Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
