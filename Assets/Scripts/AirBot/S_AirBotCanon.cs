using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AirBotCanon : MonoBehaviour
{

    private GameObject player;

    private void Start() {

        player = GameObject.FindWithTag("pivotplayer");
    }

    private void Update() {

        if (player != null) {

            Vector3 directionToPlayer = -(player.transform.position - transform.position);

            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }


}
