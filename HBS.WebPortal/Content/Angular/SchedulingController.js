HeartbeatApp.controller("SchedulingController", function AppController($scope, $location, HeartbeatService) {
    $scope.page = "Heartbeat Service Portal";
    $scope.ProviderDashboard = [];
    $scope.ReminderDashboard = ['23 Patients have to be reminded of an upcoming appointment', "Dr. Farzana's Schedule has to be updated"]
    $scope.AssignedItems = 0;
    $scope.NoOfAppointments = 0;
    $scope.DueDateItems = 0;
    $scope.init = function () {
        var resource = 'Dashboard?companyId=' + $('#company').val() + '&userId=' + $('#user').val();
        HeartbeatService.GetData($scope.LoadAlerts, $scope.Error, resource);

        var resource = 'Dashboard?companyId=' + $('#company').val();
        HeartbeatService.GetData($scope.LoadAppointment, $scope.Error, resource);
    }
    $scope.LoadAppointment = function (response) {        
        $scope.ProviderDashboard = response;
        if (response.length > 0) {
            $("#dvAppointment").show();
            $("#dvEmpty").hide();
        }
        else {
            $("#dvEmpty").show();
            $("#dvAppointment").hide();
        }
        $scope.$apply();
    };
    $scope.LoadAlerts = function (response) {
        $scope.AssignedItems = response.AssignedItems;
        $scope.NoOfAppointments = response.NoOfAppointments;
        $scope.DueDateItems = response.DueDateItems;
        $scope.$apply();
    };
    $scope.Error = function (result) {

        alert("FAILED : " + result.status + ' ' + result.statusText);
    };
});
   