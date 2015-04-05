HeartbeatApp.controller("StudentController", function AppController($scope, $location,$window, HeartbeatService) {

    $scope.Student = {};

    $scope.SaveStudent = function () {
        var resource = 'Student'
        HeartbeatService.PostDataToApi($scope.AddSuccess, $scope.Error, resource, $scope.Student);

    };

    $scope.AddSuccess = function (response) {
        alert('Registration successful! Thank you for registrating to this course.')
        window.location.href = "../";
       
    };
    $scope.Error = function (result) {
        //window.location.href = "../";
        alert("FAILED : " + result.status + ' ' + result.statusText);
       
        //$scope.$apply(function () { $location.href = $location.host; $location.path($location.host + "/Home"); });
    };
}
);