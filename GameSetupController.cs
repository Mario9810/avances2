using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()    
    {
        CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
    }
}
