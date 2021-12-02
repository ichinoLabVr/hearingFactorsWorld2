using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("開始");
        Logger logger = new Logger("test.txt");
        logger.Log("test1");
        logger.Log("test2");
        logger.Close();
        Debug.Log("終了");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
