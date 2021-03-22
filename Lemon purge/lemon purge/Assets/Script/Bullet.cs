using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 8f;
    public int damage = 1;

    public float lifeDuration = 2f;

    private float lifeTimer;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTimer -= Time.deltaTime;

        if (lifeTimer < 0f)
        {
            Destroy(gameObject);
        }


    }


}
