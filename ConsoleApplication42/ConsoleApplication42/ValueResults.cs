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

        public ValueResults(string value, double importance)
        { 
            this.Value = value;
            this.Importance = importance;
        }
        public string Value { get; private set; }

        public double Importance { get; private set; }


    }
}
