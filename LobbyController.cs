using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject cancelButton;
    [SerializeField] private int roomSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if(startButton) startButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuickStart()
    {
        if (startButton) startButton.SetActive(false);
        if (cancelButton) cancelButton.SetActive(true);

        PhotonNetwork.JoinRandomRoom();

    }

    public void QuickCancel()
    {
        if (startButton) startButton.SetActive(true);
        if (cancelButton) cancelButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room available");
        CreateRoom();

    }

    void CreateRoom()
    {
        Debug.Log("Creating room");
        int randomRN = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom("Room" + randomRN, roomOps);
        Debug.Log(randomRN);

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Creating room failed, trying again");
        CreateRoom();
    }
}
