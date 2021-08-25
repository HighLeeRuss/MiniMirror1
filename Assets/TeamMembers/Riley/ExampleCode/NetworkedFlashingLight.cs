using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace RileyMcGowan
{
    public class NetworkedFlashingLight : NetworkBehaviour
    {
        private Light mainLight;
        void Start()
        {
            mainLight = GetComponent<Light>();
        }

        void FixedUpdate()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i > 4)
                {
                    Color currentColour = new Color(Random.value, Random.value, Random.value);
                    if (isServer)
                    {
                        Debug.Log(currentColour);
                        RpcChangeLightColour(currentColour);
                    }
                }
            }
        }

        [ClientRpc]
        private void RpcChangeLightColour(Color colourToChange)
        {
            if (mainLight != null)
            {
                mainLight.color = colourToChange;
            }
            else
            {
                mainLight = GetComponent<Light>();
                mainLight.color = colourToChange;
            }
        }
    }
}