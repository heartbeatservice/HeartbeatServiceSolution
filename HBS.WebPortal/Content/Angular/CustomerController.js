HeartbeatApp.controller("CustomerController", function AppController($scope, $location, HeartbeatService) {

    $scope.Customers = [];

    $scope.clearCustomer = function () {
       
        $scope.Customer = {};
       
    };
    $scope.GridOptions = {
        data: 'Customers',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'FirstName', displayName: 'First Name', enableCellEdit: true, width: 150 },
                     { field: 'LastName', displayName: 'Last Name', enableCellEdit: true, width: 150 },
                     { field: 'DateOfBirth', displayName: 'Date Of Birth', enableCellEdit: true, width: 150 },
                     { field: 'Address1', displayName: 'Address 1', enableCellEdit: true, width: 300 },
                     { field: 'City', displayName: 'City', enableCellEdit: true, width: 150 },
                     { field: 'State', displayName: 'State', enableCellEdit: true, width: 50 },
                     { field: 'Zip', displayName: 'Zip', enableCellEdit: true, width: 100}
                     //, cellTemplate: "<div class='AddButton' ng-click='CallUpdateService(row.rowIndex);' ><span class='glyphicon glyphicon-th' data-toggle='tooltip'  data-html='true' title='{{row.entity[col.field]}}'></span></div>" 
        ]



    };
    $scope.AddCustomer = function () {
        $scope.Customer.CompanyId = $('#company').val();
        $scope.Customer.CreatedBy = $('#user').val();
        $scope.Customer.Active = true;
        var resource = 'Customer';
        HeartbeatService.PostData($scope.AddSuccess, $scope.Error, resource, $scope.Customer);
        $('#dismiss').click();
    };

    $scope.AddSuccess = function (response) {
        $scope.Customer.CustomerId = response;
        $scope.Customers.push($scope.Customer);
        $scope.$apply();
    };

    $scope.Error = function (result) {

        alert("FAILED : " + result.status + ' ' + result.statusText);
    };
});