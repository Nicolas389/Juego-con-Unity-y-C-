using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Pausar : MonoBehaviour
{

    public GameObject menuPausa;
    bool pausado;
    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false);
        pausado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausado)
        {
            Pausa();
            pausado = true;

        }else if (Input.GetKeyDown(KeyCode.Escape) && pausado)
        {
            Reanudar();
            pausado=false;
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }
}
