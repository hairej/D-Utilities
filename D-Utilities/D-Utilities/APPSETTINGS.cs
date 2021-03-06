﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Utilities
{
    public static class APPSETTINGS
    {
        public static string AD_Domain
        {
            get
            {
                return ConfigurationManager.AppSettings["Domain"];
            }
        }

        public static string ApiUser
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiUser"];
            }
        }
        public static string ApiPass
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiPass"];
            }
        }
    }
}
