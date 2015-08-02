HeartbeatApp.controller("ProfessionalController", function AppController($scope, $location, HeartbeatService) {
  
    $scope.Professionals = {};
    $scope.Professional = {};
    $scope.CompanyId = $('#company').val();
    $scope.SearchParam = '';
    
  


    $scope.GridOptions = {
        data: 'Professionals',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'FirstName', displayName: 'First Name', enableCellEdit: true, width: 200 },
                     { field: 'LastName', displayName: 'Last Name', enableCellEdit: true, width: 200 },
                     { field: 'ProfessionalIdentificationNumber', displayName: 'Professional ID #', enableCellEdit: true, width: 200 },
                     { field: 'Phone', displayName: 'Phone', enableCellEdit: true, width: 200 },
                     { field: 'ProfessionalId', displayName: 'View/Edit', enableCellEdit: true, width: 100, cellTemplate: "<button style='margin-left:20px;' class='btn-small btn-danger' ng-click='EditProfessional(row.entity[col.field]);' ><span class='glyphicon glyphicon-pencil'></span></button>" },

           
       ]
    };

    $scope.clearProfessional = function () {

        $scope.Professional = {};

    };

    $scope.AddProfessional = function () {
        $scope.Professional.CompanyId = $('#company').val();
        $scope.Professional.CreatedBy = $('#user').val();
        $scope.Professional.ProfessionalTypeId = 1;
        $scope.Professional.Active = true;
        var resource = 'Professional'
        HeartbeatService.PostData($scope.AddSuccess, $scope.Error, resource, $scope.Professional);

    };
    
    $scope.UpdatePIrofesspional = function () {
        var resource = 'Professional/' + $scope.Professional.ProfessionalId;
        HeartbeatService.PutData($scope.EditSuccess, $scope.Error, resource, $scope.Professional);
    };

    $scope.EditSuccess = function (response) {
        alert("Updated successfully");
        $scope.ProfessionalSearch();
        $('#dismissEdit').click();
    };
    $scope.Error = function (result) {

        alert("FAILED : " + result.status + ' ' + result.statusText);
    };

    $scope.AddSuccess = function (response) {
       
        $('#dismiss').click();
        alert("Added successfully");
       
    };

    $scope.ProfessionalSearch = function () {

        var myParams = $scope.SearchParam.split(",");
        var dob = '';
        var name = '';
        if (myParams.length > 0) {
            for (i = 0; i < myParams.length; i++) {
               name = myParams[i].trim();               
            }
        }
        else {            
            name = '-1';
        }

        var resource = 'Professional?companyId=' + $scope.CompanyId + '&ProfessionalName=' + name;
        HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);

    };
    $scope.SearchSuccess = function (data) {
        $scope.Professionals = data;
        $scope.$apply();
    };
    $scope.EditProfessional = function (ProfessionalId) {
        var resource = 'Professional?id=' + ProfessionalId;
        HeartbeatService.GetData($scope.GetSuccess, $scope.Error, resource);
    };
    $scope.GetSuccess = function (response) {
        $scope.Professional = response;
        $scope.$apply();
        $('#editbtn').click();
    };
    $scope.resetProfessional = function () {
        var resource = 'Professional?id=' + $scope.Professional.ProfessionalId;
        HeartbeatService.GetData($scope.GetResetSuccess, $scope.Error, resource);
    };
    $scope.GetResetSuccess = function (response) {
        $scope.Professional = response;
        $scope.$apply();
    };
});
   