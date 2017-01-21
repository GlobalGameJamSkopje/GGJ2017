using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoptaScript : MonoBehaviour {

    public GameObject WinCanvas;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Particle")
        {
            Destroy(collision.gameObject);
        }
    }
    public void DestroyMe()
    {
        WinCanvas.SetActive(true);
        Destroy(this.gameObject);

    }

}
