﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Utils
{
    public class ChemElecAnlSetter
    {
        private static IList<String> _experiment,_unit ,_stMethod;
        private static ObservableCollection<double> _result;
        public IList<Expirments> expirments = new List<Expirments>();
        public ChemElecAnlSetter()
        {

            Expirments expirment = new Expirments();
            String[] s= { "Specific Gravity", "Color", "Impurities", "Water Content", "Total Acidity",
                "Break down Voltage", "Power Factor", "Inter Facial Tension", "Kinematics Viscosity",
                "Flash Point Open", "Copper Corrosion" };
            for(int i = 0; i < s.Length; ++i)
            {
                expirment = new Expirments();
                expirment.name = s[i] ;
                expirments.Add(expirment);
            }

            s = new string[] { "at 15.5 °C", ".", ".", "ppm", "mg KOH / g oil", "KV/2.5 mm", "Dyne/cm (mN/m)", "at 40 °C (CST)", "°C", "."};
            for (int i = 0; i < s.Length; ++i)
            {
                expirments.ElementAt(i).unit = s[i] ;
            }

            s = new string[] {"A S TM D1298", "A S TM D1500", "A S TM D1796", "IEC 733", "IP 1", "IEC 156",
                              "A S TM D924", "A S TM 971",  "A S TM D445",  "A S TM D92",  "A S TM D130", };
            for (int i = 0; i < s.Length; ++i)
            {
                expirments.ElementAt(i).testingMethod = s[i] ;
            }

            
    }

        public static IList<String> experiment
        {
            get { return _experiment; }
            set { _experiment = value; }
        }
        public static IList<String> unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        public static IList<String> stMethod
        {
            get { return _stMethod; }
            set { _stMethod = value; }
        }
        public static ObservableCollection<double> result
        {
            get { return _result; }
            set { _result = value; }
        }


    }
    public class Expirments
    {
        public string name { get; set; }
        public string unit { get; set; }
        public string testingMethod { get; set; }
    }
}
