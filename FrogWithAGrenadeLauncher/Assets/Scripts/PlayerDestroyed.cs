using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyed : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDestroy()
    {
        GameManager.GameOver();
    }
}
