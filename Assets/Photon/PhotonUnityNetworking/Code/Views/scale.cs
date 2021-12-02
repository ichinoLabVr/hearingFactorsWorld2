using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class scale : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 Speaker;
    void Start()
    {
    }
    public void Scale()
    {
        Debug.Log(((((PhotonNetwork.CurrentRoom.PlayerCount / 8) + 1))));
        Speaker = gameObject.transform.localScale;
        Speaker.x *= ((((PhotonNetwork.CurrentRoom.PlayerCount / 8) + 1)));
        Speaker.z *= ((((PhotonNetwork.CurrentRoom.PlayerCount / 8) + 1)));
        gameObject.transform.localScale = Speaker;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
