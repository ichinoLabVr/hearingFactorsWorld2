using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MuteTrigger : MonoBehaviourPunCallbacks
{

    private void Start()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.IsMine)
        {
            other.gameObject.tag = "SpeakerMute";
            Debug.Log(other.gameObject.tag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!photonView.IsMine)
        {
            other.gameObject.tag = "Speaker";
            Debug.Log(other.gameObject.tag);
        }
    }
}