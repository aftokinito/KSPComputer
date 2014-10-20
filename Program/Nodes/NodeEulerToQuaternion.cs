﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSPFlightPlanner.Program.Connectors;
namespace KSPFlightPlanner.Program.Nodes
{
    [Serializable]
    public class NodeEulerToQuaternion : Node
    {

        protected override void OnCreate()
        {
            Out<SQuaternion>("Quaternion");
            In<double>("X");
            In<double>("Y");
            In<double>("Z");
        }
        protected override void OnUpdateOutputData()
        {
            var x = In("X").AsFloat();
            var y = In("Y").AsFloat();
            var z = In("Z").AsFloat();
            Out("Quaternion", new SQuaternion(Quaternion.Euler(x, y, z)));
        }
    }
}
