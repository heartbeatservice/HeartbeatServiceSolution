HeartbeatApp.controller("HeartbeatController", function AppController($scope, $location, HeartbeatService) {
   
    $scope.menuItems = [{ name: 'Home', cls: 'nav active', url: 'home/index' }, { name: 'About Us', cls: 'nav', url: 'home/about' , submenu:[{name:'Vision' }] }, { name: 'Contact Us', cls: 'nav', url: 'Home/Contact' }];


    $scope.url = $location.host();
    $scope.path = $location.path();
    $scope.port = $location.port();
    $scope.init = function () {

        $scope.constructMenu();
    };
    $scope.loginSucess = function (response) {
        $scope.User = response;
        if ($scope.User.UserId > 0) {
            $scope.constructMenu();
            $scope.$apply();
           // window.location.href = "/home/about";
        }
    };

    $scope.ErrorLogin = function (error) {
        alert('something went wrong');
    };

    $scope.ValidateUser = function () {
 
        var obj = { "UserName": "Waleed", "Password": "welcome" };
       obj.UserName=$('#user').val();
       obj.Password = $('#pass').val();
       HeartbeatService.PostData($scope.loginSucess, $scope.ErrorLogin, 'Security',obj );
       
    };
   
    $scope.constructMenu = function () {
        var mainMenu = document.getElementById('menu');
        var menuItem;
        mainMenu.innerHTML='';
        for (var i = 0; i < $scope.menuItems.length; i++) {
            menuItem = document.createElement('li');
            menuItem.setAttribute("class", "nav");
            menuItem.innerHTML = '<a href=http://'+$scope.url+':'+$scope.port+'/'+$scope.menuItems[i].url+'/>'+$scope.menuItems[i].name+'</a>';
            mainMenu.appendChild(menuItem);
        }


    };
    //End of Scope Function
}
);