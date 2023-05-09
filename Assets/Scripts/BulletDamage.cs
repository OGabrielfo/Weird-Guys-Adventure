using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public GameObject particleSystemPrefab;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Damage");

            gameObject.SetActive(false);

            GameObject particleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
            particleSystem.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            // Desativa a bala original e ativa o sistema de partículas da bala quebrada
            gameObject.SetActive(false);

            GameObject particleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
            particleSystem.SetActive(true);
        }
    }


}
