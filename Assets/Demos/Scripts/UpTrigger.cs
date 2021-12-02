using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UpTrigger : MonoBehaviourPunCallbacks
{
    private bool _isStageChange = false;
    int num = 0;

    public GameObject cam;

    private void Start () {

    }

    private void Update () {
        if(_isStageChange && num == 1){
            if (photonView.IsMine) {
                Transform camTransform = cam.transform;
                Vector3 pos = camTransform.position;
                pos.y = 2.367743f;
                camTransform.position = pos;
                num = 0;
            }
        }

        if(!_isStageChange && num == 0) {
            if (photonView.IsMine) {
                Transform camTransform = cam.transform;
                Vector3 pos = camTransform.position;
                pos.y = 1.367743f;
                camTransform.position = pos;

                num = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "UpPoint"){
            if (photonView.IsMine) {
                _isStageChange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if(other.gameObject.tag == "UpPoint"){
            if (photonView.IsMine) {
                _isStageChange = false;
            }
        }
    }
}