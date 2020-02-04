using UnityEngine;
using System.Collections;

public class OnJoinedInstantiate : Photon.MonoBehaviour
{
    public Transform SpawnPosition;
    public float PositionOffset = 2.0f;
    //public GameObject[] PrefabsToInstantiate;
    public static int count; // set in inspector
    Vector3 spawnspot;
    public static string playerName = "Aracturement";
    private PhotonView view;

    void Start()
    {
        spawnspot = new Vector3(54, 10, -55);
        playerName = "Aracturement#" + Random.Range(0, 999);
        //view = GetComponent<PhotonView>();
    }



    public void OnJoinedRoom()
    {

        PhotonNetwork.playerName = playerName;
        PhotonNetwork.Instantiate("Goblin", spawnspot, Quaternion.Euler(-30, -45, 0), 0);
        //view.RPC("Spawn", PhotonTargets.AllBuffered);
        

        /*if (this.PrefabsToInstantiate != null)
        {
            foreach (GameObject o in this.PrefabsToInstantiate)
            {
                Debug.Log("Instantiating: " + o.name);

                Vector3 spawnPos = Vector3.up;
                if (this.SpawnPosition != null)
                {
                    spawnPos = this.SpawnPosition.position;
                }

                Vector3 random = Random.insideUnitSphere;
                random.y = 0;
                random = random.normalized;
                Vector3 itempos = spawnPos + this.PositionOffset * random;

                count = PhotonNetwork.countOfPlayers;

                if (count == 1)
                {
                    PhotonNetwork.Instantiate("Player", itempos, Quaternion.Euler(-30, 45, 0), 0);
                }

                else if (count == 2)
                {
                    PhotonNetwork.Instantiate("Players", itempos, Quaternion.Euler(-30, 45, 0), 0);
                }

            }
        }*/
        Debug.Log("count:" +count);
    }

    public void Spawn()
    {
        
    }

    void Update()
    {

    }
}
