HeartbeatApp.controller("ProfessionalController", function AppController($scope, $location, HeartbeatService) {
    $scope.Professional = [];
    $scope.Professional= {};
    
    
  


    $scope.GridOptions = {
        data: 'Professional',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'FirstName', displayName: 'First Name', enableCellEdit: true, width: 100 },
                     { field: 'LastName', displayName: 'Last Name', enableCellEdit: true, width: 100 },
                     { field: 'ProfessionalIdentificationNumber', displayName: 'Professional ID #', enableCellEdit: true, width: 100 },
               { field: 'Phone', displayName: 'Phone', enableCellEdit: true, width: 100 },

           
       ]
    };

    $scope.clearProfessional = function () {

        $scope.Professional = {};

    };

    $scope.AddProfessional = function () {
        $scope.Customer.CompanyId = $('#company').val();
        $scope.Customer.CreatedBy = $('#user').val();
        $scope.Professional.Active = true;
        var resource = 'Professional'
        HeartbeatService.PostData($scope.AddSuccess, $scope.Error, resource, $scope.Profesional);

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
        $scope.Professional.ProfessionalId = response;
        $scope.Professional.push($scope.Professional);
        $scope.$apply();
        $('#dismiss').click();
        $scope.ShowInsuranceForm();  //TODO  need to fix this one here. 
    };
});
   