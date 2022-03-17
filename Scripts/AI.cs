using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Josephus.AIPackages
{
    public class AI : MonoBehaviour
    {
        public AIPackage[] Packages;

        public NavMeshAgent Agent;

        AIPackage currentPackage;

        // Update is called once per frame
        void Update()
        {
            if (currentPackage)
            {
                currentPackage.OnUpdate(this);
                if(!currentPackage.MustComplete || currentPackage.HasCompleted(this))
                {
                    var nextPossiblePackage = GetPackage();
                    if(nextPossiblePackage != null)
                    {
                        currentPackage.OnFinish(this);
                        currentPackage = GetPackage();
                        currentPackage.OnStart(this);
                    }
                }
            }
            else
            {
                currentPackage = GetPackage();
                if(currentPackage)
                    currentPackage.OnStart(this);
            }
        }

        AIPackage GetPackage()
        {
            foreach (var package in Packages)
            {
                if(package.IsConditionMet(this))
                    return package;
            }

            return null;
        }
    }
}