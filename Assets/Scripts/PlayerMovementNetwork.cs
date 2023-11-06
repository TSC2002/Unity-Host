using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMovementNetwork : NetworkBehaviour
{
    [SerializeField] float MoveSpeed = 3f;
    [SerializeField] private Transform SpherePrefab;
    private Transform SphereObject;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (!IsOwner) return;

        Vector3 MoverDireccion = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) MoverDireccion.z = 1f;
        if (Input.GetKey(KeyCode.S)) MoverDireccion.z = -1f;
        if (Input.GetKey(KeyCode.A)) MoverDireccion.x = -1f;
        if (Input.GetKey(KeyCode.D)) MoverDireccion.x = 1f;

        if (Input.GetKeyDown(KeyCode.T))
        {
            TestServerRpc();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
           
        }

        transform.Translate(MoverDireccion * MoveSpeed * Time.deltaTime);

        
    }

    [ServerRpc]
    private void TestServerRpc() {

        SphereObject = Instantiate(SpherePrefab, transform.position, Quaternion.identity);

        SphereObject.GetComponent<NetworkObject>().Spawn(true);
    }

    [ClientRpc]
    private void TestClientRpc() { 
    
        Debug.Log("Test Client RPC");
    }
}
