using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server;

namespace ServerService
{
    public partial class ServerService : ServiceBase
    {

        private Thread th;

        public ServerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            th = new Thread(new ParameterizedThreadStart(Server.Program.MainTH));
            th.IsBackground = true;
            th.Start((object)args);
        }

        protected override void OnStop()
        {
            if ((th != null) && th.IsAlive)
                th.Abort();
        }
    }
}
