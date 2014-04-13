HeartbeatApp.controller("HeartbeatController", function AppController($scope, $location, HeartbeatService) {
   
    $scope.menuItems = [{ name: 'Home', cls: 'nav active', url: 'home/index' }, { name: 'About Us', cls: 'nav', url: '#' , submenu:[{name:'Vision' }] }, { name: 'Contact Us', cls: 'nav', url: 'Home/Contact' }];
    $scope.url = $location.host();
    $scope.path = $location.path();
    $scope.port = $location.port();
    $scope.init = function () {

        HeartbeatService.PostData($scope.loginSucess, $scope.ErrorLogin, 'Security', { "UserName": "Waleed", "Password": "welcome" });
    };
    $scope.loginSucess = function (response) {
        $scope.User = response;
        $scope.$apply();
    };

    $scope.ErrorLogin = function (error) {
        alert('something went wrong');
    };

   
    //End of Scope Function
}
);