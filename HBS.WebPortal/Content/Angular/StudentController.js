HeartbeatApp.controller("StudentController", function AppController($scope, $location, HeartbeatService) {

    $scope.Student = {};

    $scope.SaveStudent = function () {
        var resource = 'Student'
        HeartbeatService.PostData($scope.AddSuccess, $scope.Error, resource, $scope.Student);

    };

    $scope.AddSuccess = function (response) {
        alert(response);
        $('#redirect').click();
        //$scope.$apply(function () { $location.href = $location.host;$location.path($location.host + "/Home"); });
    };
    $scope.Error = function (result) {

        alert("FAILED : " + result.status + ' ' + result.statusText);
        $('#redirect').click();
        $scope.$apply();
        //$scope.$apply(function () { $location.href = $location.host; $location.path($location.host + "/Home"); });
    };
}
);