using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolaScript : MonoBehaviour
{
    [SerializeField] Transform punta;
    public float distancia = 20f;
    [SerializeField] GameObject bala;
    [SerializeField] Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = Quaternion.AngleAxis(-88f, -punta.right) * punta.forward;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("hola");
            GameObject disparo = Instantiate(bala, punta.position, punta.rotation);
            disparo.GetComponent<Rigidbody>().AddForce(direccion * 1500);
        }

        if (punta == null) return;

        Debug.DrawRay(punta.position, direccion * distancia, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(punta.position, direccion, out hit, distancia))
        {
            if (hit.collider.CompareTag("enemigo"))
            {
                img.color = Color.red;
                Debug.Log("Detectó enemigo desde: " + punta.name);
            }
            
            if (!hit.collider.CompareTag("enemigo"))
            {
                img.color= Color.white;
            }
        }
        else
        {
            img.color = Color.white;
        }
    }
}
