using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MuteTrigger : MonoBehaviourPunCallbacks
{
    AudioSource audioSource;
    private bool _isStageChange = false;
    int num = 0;
    public string objName;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        foreach (var player in PhotonNetwork.PlayerList) {
            //Debug.Log($"{player.NickName}({player.ActorNumber})");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_isStageChange && num == 1){
            if (!photonView.IsMine) {//範囲に入ったからミュートにする
                GameObject SpeakerSound = GameObject.Find(objName);
                audioSource = SpeakerSound.GetComponent<AudioSource>();
                audioSource.mute = !audioSource.mute;

                num = 0;
            }
        }

        if(!_isStageChange && num == 0) {
            if (!photonView.IsMine) {//範囲を出たからミュート解除する
                try{
                    GameObject SpeakerSound = GameObject.Find(objName);
                    audioSource = SpeakerSound.GetComponent<AudioSource>();
                    audioSource.mute = !audioSource.mute;
                }catch{
                    ;
                }

                num = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Speaker"){
            if (!photonView.IsMine) {
                _isStageChange = true;
                objName = other.gameObject.name;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if(other.gameObject.tag == "Speaker"){
            if (!photonView.IsMine) {
                _isStageChange = false;
                objName = other.gameObject.name;
            }
        }
    }
}
