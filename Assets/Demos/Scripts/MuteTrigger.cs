using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MuteTrigger : MonoBehaviourPunCallbacks
{
    private bool _isStageChange = false;
    int num = 0;
    public AudioSource audioSource;
    private void Start()
    {
        var firstgameObject = GameObject.Find("Capsule");
        audioSource = firstgameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isStageChange && num == 1)
        {
            if (photonView.IsMine)
            {
                audioSource.mute = false;
                num = 0;
            }
        }

        if (!_isStageChange && num == 0)
        {
            if (photonView.IsMine)
            {
                audioSource.mute = true;
                num = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "UpPoint")
        {
            _isStageChange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if (other.gameObject.tag == "UpPoint")
        {
            _isStageChange = false;
        }
    }
}