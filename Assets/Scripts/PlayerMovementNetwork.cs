using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMovementNetwork : NetworkBehaviour
{
    [SerializeField] float MoveSpeed = 3f;

    private void Update()
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

        transform.Translate(MoverDireccion * MoveSpeed * Time.deltaTime);
    }

    [ServerRpc]
    private void TestServerRpc()
    {
        Debug.Log("Test Server RPC");
    }
}
