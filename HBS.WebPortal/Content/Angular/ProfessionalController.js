HeartbeatApp.controller("ProfessionalController", function AppController($scope, $location, HeartbeatService) {
  
    $scope.Professional = {};
    $scope.CompanyId = $('#company').val();
    $scope.SearchParam = '';
    
  


    $scope.GridOptions = {
        data: 'Professional',
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
    
    $scope.UpDatePIrofesspional = function () {
        var resource = 'Professional/' + $scope.Professional.ProfessionalId;
        HeartbeatService.PutData($scope.EditSuccess, $scope.Error, resource, $scope.Professional);
    };

    $scope.EditSuccess = function (response) {
        alert("Updated successfully");
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
        $scope.Professional = data;
        $scope.$apply();
    };
});
   