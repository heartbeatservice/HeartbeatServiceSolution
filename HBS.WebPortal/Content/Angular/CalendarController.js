HeartbeatApp.controller("CalendarController", function AppController($scope, $location, HeartbeatService) {
    $scope.CalendarView = "Daily";
    $scope.currentDate = "2014/11/20";
    $scope.professionalId = 0;
    $scope.ProfessionalSchedule = {};
    $scope.ServiceURL = "http://localhost:3687/api/ProfessionalSchedule/";
   // $scope.ServiceURL="http://services.heartbeat-biz.com/api/ProfessionalSchedule";
    $scope.init = function () {

        $scope.currentDate = $('#CurrentDate').val();
        $scope.professionalId = $('#DoctorId').val();
        $scope.loadDailyCalendar();
    };


    $scope.loadDailyCalendar = function () {

        $(function () {
            $("#scheduler").kendoScheduler({
                date: new Date($scope.currentDate),
                startTime: new Date($scope.currentDate+" 07:00 AM"),
                height: 800,
                views: [
                    { type: "day", selected: true },
                    //,
                    //{ type: "workWeek", selected: true },
                    "week",
                    "month",
                    //"agenda"
                ],
                // timezone: "Etc/UTC",
                dataSource: {
                    batch: true,
                    transport: {
                        read: {

                            beforeSend: function (xhrObj) {
                                xhrObj.setRequestHeader("Content-Type", "application/json");
                                xhrObj.setRequestHeader("Accept", "application/json");

                            },
                           
                            url: $scope.ServiceURL + $scope.professionalId,
                            dataType: "json"
                        },
                        update: {
                            beforeSend: function (xhrObj, s) {
                                xhrObj.setRequestHeader("Content-Type", "application/json");
                                xhrObj.setRequestHeader("Accept", "application/json");
                                s.data = JSON.stringify($scope.ProfessionalSchedule);
                            },
                           
                            url: $scope.ServiceURL,
                            type: "put"

                        },
                        create: {
                            beforeSend: function (xhrObj, s) {
                                xhrObj.setRequestHeader("Content-Type", "application/json");
                                xhrObj.setRequestHeader("Accept", "application/json");
                                s.data = JSON.stringify($scope.ProfessionalSchedule);
                              
                                
                            },
                            
                            url: $scope.ServiceURL,
                            type: "post"
                        },
                        destroy: {
                          
                            url: $scope.ServiceURL,
                            dataType: "jsonp"
                        },
                        parameterMap: function (options, operation) {
                            var attribString = "";
                            if (operation !== "read" && options.models) {
                                var Items = $('.k-edit-form-container > .k-edit-field');
                                for (var i = 0; i < Items.length; i++)
                                {
                                    inputVal = Items[i];

                                   attribString+= inputVal.getAttribute("data-container-for");
                                }
                                alert(JSON.stringify(options.models));
                                switch(operation)
                                {
                                    case "create":
                                        $scope.ProfessionalSchedule = options.models[0];
                                        $scope.ProfessionalSchedule.ProfessionalId = $scope.professionalId;
                                        $scope.ProfessionalSchedule.UserId = 1;
                                        break;
                                    case "update":
                                        $scope.ProfessionalSchedule = options.models[0];
                                        break;
                                    case "destroy":
                                        alert("Destroyed")
                                        break;
                                    default:
                                        alert("No action Performed");
                                }
                            }
                        }
                    },
                    schema: {
                        model: {
                            id: "taskId",
                            fields: {
                                taskId: { from: "TaskID", type: "number" },
                                title: { from: "Title", defaultValue: "No title", validation: { required: true } },
                                start: { type: "date", from: "Start" },
                                end: { type: "date", from: "End" },
                                startTimezone: { from: "StartTimezone" },
                                endTimezone: { from: "EndTimezone" },
                                description: { from: "Description" },
                                recurrenceId: { from: "RecurrenceID" },
                                recurrenceRule: { from: "RecurrenceRule" },
                                recurrenceException: { from: "RecurrenceException" },
                                ownerId: { from: "OwnerID", defaultValue: 1 },
                                isAllDay: { type: "boolean", from: "IsAllDay" },
                                ProfessionalId: { type: "number", from: "ProfessionalId" },
                                UserId: { type: "number", from: "UserId" }
                            }
                        }
                    },
                    filter: {
                        logic: "or",
                        filters: [
                            { field: "ownerId", operator: "eq", value: 1 },
                            { field: "ownerId", operator: "eq", value: 2 },
                            { field: "ownerId", operator: "eq", value: 3}
                        ]
                    }
                },
                resources: [
                    {
                        field: "ownerId",
                        title: "Owner",
                        dataSource: [
                            { text: "Alex", value: 1, color: "#f8a398" },
                            { text: "Bob", value: 2, color: "#51a0ed" },
                            { text: "Charlie", value: 3, color: "#56ca85" }
                        ]
                    }
                ]
            });

            $("#people :checkbox").change(function (e) {
                var checked = $.map($("#people :checked"), function (checkbox) {
                    return parseInt($(checkbox).val());
                });

                var scheduler = $("#scheduler").data("kendoScheduler");

                scheduler.dataSource.filter({
                    operator: function (task) {
                        return true;
                    }
                });
            });
        });
    }
});