using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Video;
using UnityEngine.Audio;
using System;

public class NierSP : MonoBehaviourPunCallbacks
{
    public float speed;
    public Rigidbody rb;
    private GameObject[] targets;
    GameObject nierobj;
    Transform unitychanpos;
    Transform targetpos;
    GameObject noisecube;
    Transform tf;
    AudioSource audioSource;

    private GameObject closeEnemy;
    // Start is called before the first frame update
    void Start()
    {
        noisecube = transform.Find("NoiseCube").gameObject;
        tf = noisecube.GetComponent<Transform>();
        audioSource = noisecube.GetComponent<AudioSource>();
    }
    GameObject nier()
    {

        targets = GameObject.FindGameObjectsWithTag("Speaker");
        float closeDist = 1000;
        foreach (GameObject t in targets)
        {
            float tDist = Vector3.Distance(transform.position, t.transform.position);
            // もしも「初期値」よりも「計測した敵までの距離」の方が近いならば、
            if (closeDist > tDist)
            {
                // 「closeDist」を「tDist（その敵までの距離）」に置き換える。
                // これを繰り返すことで、一番近い敵を見つけ出すことができる。
                closeDist = tDist;

                // 一番近い敵の情報をcloseEnemyという変数に格納する（★）
                closeEnemy = t;
            }
        }
        return closeEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb.IsSleeping() && photonView.IsMine)
        {
            nierobj = nier();
            unitychanpos = this.transform;
            targetpos = nierobj.transform;
            Vector3 unipos = unitychanpos.position;
            Vector3 tarpos = targetpos.position;

            float x = (unipos.x * 2) - tarpos.x;
            float z = (unipos.z * 2) - tarpos.z;
            float volume = (Mathf.Sqrt(Mathf.Pow(tarpos.x - unipos.x, 2f) + Mathf.Pow(tarpos.z - unipos.z, 2f)) / 10) - 0.02f;
            noisecube.transform.position = new Vector3(x, 1, z);
            audioSource.volume = volume;
        }
    }
}