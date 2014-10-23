﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSPComputer.Nodes;
using KSPComputer.Connectors;
namespace DefaultNodes
{
    [Serializable]
    public class NodeIncrement : ExecutableNode
    {
        int count = 0;
        protected override void OnCreate()
        {
            In<double>("Start");
            In<double>("Step");
            Out<double>("Value");
            In<Connector.Exec>("Reset", true);
        }
        protected override void OnExecute(ConnectorIn input)
        {
            if (input == In("Reset"))
                count = 0;
            else
            {
                Out("Value", In("Start").AsDouble() + count * In("Step").AsDouble());
                count++;
            }
            ExecuteNext();
        }
    }
}