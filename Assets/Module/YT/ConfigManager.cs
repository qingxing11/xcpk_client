using Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ConfigManager
{
    private static Configs config;
    public static Configs Configs
    {
        get
        {
            if (config == null)
            {
                config = new Configs();
            }
            return config;
        }
    }
}