using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class SpawnTowerControl : MonoBehaviour

{
    public GameObject TorreEnConstruccion;
    public Vector3 posicion;
    public GameObject Torre;
    // Start is called before the first frame update
    void Start()
    {
    }

    void muroHecho()
    {
        Instantiate(Torre, transform.position + posicion, Quaternion.identity);
    }

    private void OnMouseDown()
        {
           Instantiate(TorreEnConstruccion, transform.position+posicion, Quaternion.identity);
            Invoke("muroHecho", 5f);
      //  Destroy(gameObject);
        }
    }
