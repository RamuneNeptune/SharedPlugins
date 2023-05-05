using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DRS.ModulesMod.Handlers
{
    public class SeamothHandler : MonoBehaviour
    {
        public static List<GameObject> seamoths = new List<GameObject>();
        public SeaMoth seamoth;

        public void OnEnable() => seamoths.Add(gameObject);
        public void OnDisable() => seamoths.Remove(gameObject);

        public void Start()
        {
            seamoth = gameObject.GetComponentInChildren<SeaMoth>();
        }
    }
}