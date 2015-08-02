using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Services;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR_Web.hub
{
    [HubName("taskHub")]
    public class Taskhub : Hub
    {
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000);
        private static int currentId = 0;
        private Timer _timer;

        public List<FakeTask> GetTasks()
        {
            return new TaskService().GetAllTasks();
        }

        public void UpdateTasks()
        {
            _timer = new Timer(UpdateTaskStatus, null, _updateInterval, _updateInterval);
        }

        private void UpdateTaskStatus(Object state)
        {
            var tS = new TaskService();
            var task = tS.UpdateTask(currentId%10);
            currentId++;
            Clients.All.updateTaskStatus(task);
        }

    }
}