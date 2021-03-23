using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 14f;
    public int damage = 1;

    public float lifeDuration = 1f;

    private float lifeTimer;

    

    // Start is called before the first frame update
    void OnEnable()
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
            gameObject.SetActive(false);
        }


    }


}
