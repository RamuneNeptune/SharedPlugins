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
        public SeaMoth seamoth;
        public Animator animator;
        public Vehicle vehicle;
        
        public void Start()
        {
            seamoth = gameObject.GetComponentInChildren<SeaMoth>();
            animator = gameObject.GetComponent<Animator>();
            vehicle = gameObject.GetComponent<Vehicle>();
        }

        public void SetLastValues()
        {

        }
    }
}