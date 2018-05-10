using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Quartz;

namespace WinFom.Model
{
    public class SimpleQuartzJob : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(SimpleQuartzJob));
        void IJob.Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
