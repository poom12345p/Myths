using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerUlti : Photon.MonoBehaviour {

    int id, regen, pad, upHeal, turn;
    int count = 12;
    int range = 20;
    bool activate = false;
    bool onceheal = true;
    PhotonView heal;

    // Use this for initialization
    void Start () {

        heal = this.photonView;
        id = PlayerInfo.turn % 4;
        turn = PlayerInfo.turn;
        pad = RandomDie.pad;

        if (PlayerInfo.skilllvl[2] == 1)
        {
            regen = 30 + upHeal;
        }

        else if (PlayerInfo.skilllvl[2] == 2)
        {
            regen = 55 + upHeal;
        }

        else if (PlayerInfo.skilllvl[2] == 3)
        {
            regen = 80 + upHeal;
        }

        Debug.Log(regen);
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerInfo.qualify[2] == 2)
        {
            upHeal = 80;
            count = 16;
        }

        if (PlayerInfo.qualify[1] == 3)
        {
            range = 25;
        }

        if (turn != PlayerInfo.turn && !PlayerInfo.isSkip)
        {
            turn = PlayerInfo.turn;
            activate = true;
            onceheal = true;
        }

        if (activate)
        {
            heal.RPC("UpdateHeal", PhotonTargets.All, regen, id, pad);
            count--;           
            activate = false;
        }

        if (count == 0)
        {
            heal.RPC("DestroyHeal", PhotonTargets.All);
        }
    }

    [PunRPC]
    public void UpdateHeal(int regen, int ids, int setpad)
    {
        if (ids == PlayerInfo.Turnnum && onceheal)
        {
            if (Vector3.Distance(Movement.Waypoints[RandomDie.pad].position, Movement.Waypoints[setpad].position) <= range)
            {
                if (PlayerInfo.hp + regen >= PlayerInfo.basehp)
                {
                    PlayerInfo.hp = PlayerInfo.basehp;
                }

                else
                {
                    PlayerInfo.hp += regen;
                }

                onceheal = false;

            }
          
        }
    }

    [PunRPC]
    public void DestroyHeal()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
