using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttonscript : MonoBehaviour
{
    [SerializeField] public string scene;
   public void onClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
