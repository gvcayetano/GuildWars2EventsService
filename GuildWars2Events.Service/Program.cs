﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace GuildWars2Events.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            HostFactory.Run(x =>                                 //1
            {
                x.Service<GuildWars2Events>(s =>                        //2
                {
                    s.ConstructUsing(name => new GuildWars2Events());     //3
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());               //5
                });
                x.RunAsLocalSystem();                            //6

                x.SetDescription("A Guild Wars 2 API Service");        //7
                x.SetDisplayName("GuildWars2Events.Service");                       //8
                x.SetServiceName("GuildWars2Events.Service");                       //9
            }); 
        }
    }
}
