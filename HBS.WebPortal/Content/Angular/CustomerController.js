HeartbeatApp.controller("CustomerController", function AppController($scope, $location, HeartbeatService) {

    $scope.Customers = [];
    $scope.SearchParam = '';
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
                     { field: 'FirstName', displayName: 'First Name', enableCellEdit: true, width: 100 },
                     { field: 'LastName', displayName: 'Last Name', enableCellEdit: true, width: 100 },
                     { field: 'DateOfBirth', displayName: 'DOB', enableCellEdit: true, width: 100 },
               { field: 'HomePhone', displayName: 'Home Phone', enableCellEdit: true, width: 100 },
               { field: 'CellPhone', displayName: 'Cell Phone', enableCellEdit: true, width: 100 },
               { field: 'Address1', displayName: 'Address', enableCellEdit: true, width: 250 },
               { field: 'City', displayName: 'City', enableCellEdit: true, width: 125 },
        { field: 'CustomerId', displayName: 'Insurance', enableCellEdit: true, width: 80, cellTemplate: "<button style='margin-left:20px;'class='btn-small btn-warning' ng-click='EditUser(row.entity[col.field]);' ><span  class='glyphicon glyphicon-folder-open'></span></button>" },
         { field: 'CustomerId', displayName: 'Edit', enableCellEdit: true, width: 75, cellTemplate: "<button style='margin-left:20px;' class='btn-small btn-danger' ng-click='EditUser(row.entity[col.field]);' ><span class='glyphicon glyphicon-pencil'></span></button>" },
          { field: 'CustomerId', displayName: 'Detail', enableCellEdit: true, width: 75, cellTemplate: "<button style='margin-left:20px;' class='btn-small btn-primary' ng-click='EditUser(row.entity[col.field]);' > <span class='glyphicon glyphicon-th-list'></span></button>" }
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

    $scope.CustomerSearch = function () {
        $scope.CompanyId = $('#company').val();
        $scope.Params = $scope.SearchParam.split(",");
        alert($scope.Params)
        if (HeartbeatService.IsDate($scope.SearchParam)) {
            $scope.dob = $scope.SearchParam.replace('/','-');
            $scope.name = '-1';

        }
        else if ($scope.SearchParam.trim() != '') {
            $scope.dob = '1-1-1900';
            $scope.name = $scope.SearchParam
        }
        else {
            $scope.dob = '1-1-1900';
            $scope.name = '-1';
        }

        var resource = 'Customer?companyId=' + $scope.CompanyId + '&customerName=' + $scope.name + '&dob=' + $scope.dob;
        HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);

    };

    $scope.SearchSuccess=function(data){
        $scope.Customers = data;
        $scope.$apply();
    };

    $scope.EditUser = function (data) {
        alert(data);
    };
});