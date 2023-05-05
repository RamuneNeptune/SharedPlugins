using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DRS.ModulesMod.Handlers
{
    public class ExosuitHandler : MonoBehaviour
    {
        public static List<GameObject> exosuits = new List<GameObject>();
        public Exosuit exosuit;

        public void OnEnable() => exosuits.Add(gameObject);
        public void OnDisable() => exosuits.Remove(gameObject);

        public void Start()
        {
            exosuit = gameObject.GetComponentInChildren<Exosuit>();
        }
    }
}