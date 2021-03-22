using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform eyes;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.player.position.x, this.eyes.position.y, this.player.position.z);

    }
}
