﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSPComputer.Types;
using KSPComputer.Nodes;
namespace KSPComputer.Connectors
{
    [Serializable]
    public class ConnectorIn : Connector
    {
        internal bool FreshData { get; set; }
        private object buffer;
        internal ConnectorIn(Type dataType, object defaultValue, bool allowMultipleConnections = false)
            : base(dataType, allowMultipleConnections)
        {
            buffer = defaultValue;
        }
        public void RequestData()
        {
            //Should always be one !
            //never called on execution nodes
            foreach (var i in connections)
            {
                i.Node.UpdateOutputData();
            }
        }
        public void Set(object data)
        {
            buffer = data;
            FreshData = true;
        }
        public T Get<T>()
        {
            var type = typeof(T);
            if(type == typeof(double))
                return (T)(object)AsDouble();
            if(type == typeof(float))
                return (T)(object)AsFloat();
            if(type == typeof(int))
                return (T)(object)AsInt();
            if(type == typeof(bool))
                return (T)(object)AsBool();
            if (type == typeof(SVector3))
                return (T)(object)AsVector3();
            if (type == typeof(SVector2))
                return (T)(object)AsVector2();
            if (type == typeof(SQuaternion))
                return (T)(object)AsQuaternion();
            if (type == typeof(string))
                return (T)(object)AsString();
            return default(T);
        }
        public string AsString()
        {
            if (buffer == null)
                return "";
            return buffer.ToString();
        }
        public int AsInt()
        {
            if (buffer is int)
                return (int)buffer;
            if (buffer is double)
                return (int)(double)buffer;
            if (buffer is float)
                return (int)(double)(float)buffer;
            int vali;
            if (int.TryParse(buffer as string, out vali))
                return vali;
            double val;
            if (double.TryParse(buffer as string, out val))
                return (int)val;
            float valf;
            if (float.TryParse(buffer as string, out valf))
                return (int)valf;
            return 0;
        }
        public double AsDouble()
        {
            if (buffer is double)
                return (double)buffer;
            if (buffer is float)
                return (double)(float)buffer;
            if (buffer is int)
                return (double)(int)buffer;
            double val;
            if (double.TryParse(buffer as string, out val))
                return val;
            float valf;
            if (float.TryParse(buffer as string, out valf))
                return (double)valf;
            return 0.0;
        }
        public float AsFloat()
        {
            if (buffer is float)
                return (float)buffer;
            if (buffer is double)
                return (float)(double)buffer;
            if (buffer is int)
                return (float)(int)buffer;
            float val;
            if (float.TryParse(buffer as string, out val))
                return val;
            double vald;
            if (double.TryParse(buffer as string, out vald))
                return (float)vald;
            return 0.0f;
        }
        public bool AsBool()
        {
            if (buffer is bool)
                return (bool)buffer;
            bool val;
            if (bool.TryParse(buffer as string, out val))
                return val;
            return false;
        }
        public SVector3 AsVector3()
        {
            if (buffer is SVector3)
                return (SVector3)buffer;
            return new SVector3();
        }
        public SVector2 AsVector2()
        {
            if (buffer is SVector2)
                return (SVector2)buffer;
            return new SVector2();
        }
        public SQuaternion AsQuaternion()
        {
            if (buffer is SQuaternion)
                return (SQuaternion)buffer;
            return new SQuaternion();
        }
    }
}