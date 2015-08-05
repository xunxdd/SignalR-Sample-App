using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public class TaskService
    {
        public string[] Owners = { "John", "Doe", "Jane", "Mary", "Mary", "Mr. T" };
        public string[] TaskNames = { "Clean Bathroom", "Clean Kitchen", "Cooking dish", "Washing dishes", "Clean office", "Vacumming", "Sorting out mails" };

        private readonly List<FakeTask> _tasks;
        public TaskService()
        {
            _tasks = new List<FakeTask>();
            var ownerCount = Owners.Length;
            var taskCount = TaskNames.Length;
            for (var i = 0; i < 10; i++)
            {
                _tasks.Add(new FakeTask
                {
                    Owner = Owners[i % ownerCount],
                    Name = TaskNames[i % taskCount] + " " + i,
                    Done = i % 3==0,
                    TaskId = i
                });

            }

        }

        public List<FakeTask> GetAllTasks()
        {
            return _tasks;
        }

        public FakeTask UpdateTask(int i)
        {
            var task = _tasks.FirstOrDefault(x => x.TaskId == i);

            if (task != null)
            {
                task.Done = !task.Done;
            }

            return task;

        }

    }
}
