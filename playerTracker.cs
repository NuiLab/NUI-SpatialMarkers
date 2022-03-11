using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerTracker : MonoBehaviour
{
    int frame = 0;
    int often = 3;
    public UdpServer server;
    public GameObject playArea;
    private void Awake() {
        server = GameObject.Find("NetworkManager").GetComponent<UdpServer>();
    }
    private void Update() {
        if(frame == often)
        {
            Vector3 loc = new Vector3(gameObject.transform.position.x-playArea.transform.position.x,gameObject.transform.position.y-playArea.transform.position.y,gameObject.transform.position.z-playArea.transform.position.z);
            float x = loc.x * Mathf.Cos(playArea.transform.rotation.x) + loc.y * Mathf.Sin(playArea.transform.rotation.x);
            float y = loc.x * -Mathf.Sin(playArea.transform.rotation.x) + loc.y * Mathf.Cos(playArea.transform.rotation.x);
            float z = loc.y * Mathf.Cos(playArea.transform.rotation.y) + loc.z * Mathf.Sin(playArea.transform.rotation.y);
            float y2 = loc.y* -Mathf.Sin(playArea.transform.rotation.y) + loc.z * Mathf.Cos(playArea.transform.rotation.y);
            server.StartServer("C" + loc.x.ToString() + "," + loc.y.ToString() + "," + loc.z.ToString());
            frame = 0;
        }
        else{
            frame++;
        }
    }
}
