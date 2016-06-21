using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApplication42
{
    public class ValueResults
    {

        public string Value { get; private set; }

        public double Importance { get; private set; }

        public ValueResults(string value, double importance)
        {
            Value = value;
            Importance = importance;
        }
    }
}
