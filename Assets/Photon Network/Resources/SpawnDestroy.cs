using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroy : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (ConnectAndJoinRandom.createRoom)
        {
            StartCoroutine("DelayDestroy");
        }

	}

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(5);
        photonView.RPC("DestroySpawn", PhotonTargets.All);
    }

    [PunRPC]
    public void DestroySpawn()
    {
        Effect.isSpawn = false;
        PhotonNetwork.Destroy(gameObject);        
    }
}
