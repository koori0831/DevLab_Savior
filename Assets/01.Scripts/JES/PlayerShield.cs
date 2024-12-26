using System;
using System.Collections;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private bool _isKeep = false;
    private WaitForSeconds _waitTime = new WaitForSeconds(5);
        
    public void SetShield(bool isKeep)
    {
        _isKeep = isKeep;
        if (_isKeep)
        {
            StartCoroutine(KeepShieldCo());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Bullet")|| other.gameObject.layer == 11)
        {
            Destroy(other.gameObject);
        }
        if(_isKeep) return; 
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
        if(_isKeep) return;
        gameObject.SetActive(false);
    }

    private IEnumerator KeepShieldCo()
    {
        yield return _waitTime;
        gameObject.SetActive(false);
    }
}
