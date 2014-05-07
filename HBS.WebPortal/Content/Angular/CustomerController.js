HeartbeatApp.controller("CustomerController", function AppController($scope, $location, HeartbeatService) {
    $scope.clearCustomer=function(){
       
        $scope.Customer = {};
   
    };
});