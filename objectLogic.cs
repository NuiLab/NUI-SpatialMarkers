using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectLogic : MonoBehaviour
{
    public bool grabed = false;
    public UdpServer server;
    private void Awake() {
        server = GameObject.Find("NetworkManager").GetComponent<UdpServer>();
    }
    public void SetGrabed(bool b)
    {
        grabed = b;
        if(b)
        {
            server.StartServer("G0");
            server.StartServer("G0");
        }
        else if(!b)
        {
            server.StartServer("G1");
            server.StartServer("G1");
        }
    }
    private void Update() {
        if(grabed)
        {
            Debug.Log(gameObject.transform.position.x.ToString() + "," + gameObject.transform.position.y.ToString() + "," + gameObject.transform.position.z.ToString());
            server.StartServer("V" + gameObject.transform.position.x.ToString() + "," + gameObject.transform.position.y.ToString() + "," + gameObject.transform.position.z.ToString());
        }
    }
}
