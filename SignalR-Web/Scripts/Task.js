// A simple background color flash effect that uses jQuery Color plugin
jQuery.fn.flash = function (color, duration) {
    var current = this.css('backgroundColor');
    this.animate({ backgroundColor: 'rgb(' + color + ')' }, duration / 2)
        .animate({ backgroundColor: current }, duration / 2);
};

$(function () {

    var taskHub = $.connection.taskHub, // the generated client-side hub proxy
        table = $('#taskTable'),
        loading = $('.loading'),
        summary = $('#summary');

    function setUpEventHandler() {
        // Wire up the buttons
        $("#AutoUpdate").click(function () {
            taskHub.server.updateTasks();
        });

    }

    function init() {
        return taskHub.server.getTasks().done(function (data) {

            loading.hide();
            setUpEventHandler();
            table.dataTable({
               "data": data,
               scrollY: 300,
               paging: false,

               "columns": [
                    { "data": "TaskId" },
                    { "data": "Name" },
                    { "data": "Owner" },
                    { "data": "Done" }
                ],
                "columnDefs": [
                    {
                        "targets": 0,
                        "visible": false
                    },
                     {
                         // The `data` parameter refers to the data for the cell (defined by the
                         // `data` option, which defaults to the column being worked with, in
                         // this case `data: 0`.
                         "render": function (rowdata, type, row) {
                             return rowdata + "atlatj";
                         },
                         "targets": 3
                     }
                ]
            });
        });
    }

    // Add client-side hub methods that the server will call
    $.extend(taskHub.client, {
        updateTaskStatus: function (task) {
            var dt = table.dataTable();
            dt.fnUpdate(task, task.TaskId); // Row
        }
    });

    // Start the connection
    $.connection.hub.start()
        .then(init);
});