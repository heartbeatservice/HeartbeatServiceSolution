HeartbeatApp.controller("HeartbeatController", function AppController($scope,$location) {
   
    $scope.menuItems = [{ name: 'Home', cls: 'nav active', url: 'home/index' }, { name: 'About Us', cls: 'nav', url: '#' , submenu:[{name:'Vision' }] }, { name: 'Contact Us', cls: 'nav', url: 'Home/Contact' }];
    $scope.url = $location.host();
    $scope.path = $location.path();
    $scope.port = $location.port();


   
    //End of Scope Function
}
);