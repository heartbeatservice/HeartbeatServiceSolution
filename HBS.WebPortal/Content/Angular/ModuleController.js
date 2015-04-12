HeartbeatApp.controller("ModuleController", function AppController($scope, $location, HeartbeatService) {

    $scope.CompanyId = $('#company').val();
    $scope.SearchParam = '';
    $scope.Modules = {};
    $scope.Module = {};
    $scope.clearModule = function () {

        $scope.Module = {};
        $scope.ModuleEntry = {};
    };
   
    $scope.GridOptions = {
        data: 'Modules',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'ModuleName', displayName: 'Module Name', enableCellEdit: true, width: 350 },
                     { field: 'ModuleDescription', displayName: 'Module Description', enableCellEdit: true, width: 320 },
      //  { field: 'ModuleEdit', displayName: 'Module Edit', enableCellEdit: true, width: 300 }
        

           
        { field: 'ModuleId', displayName: 'View/Edit', enableCellEdit: true, width: 300, cellTemplate: "<button style='margin-left:20px;' class='btn-small btn-danger' ng-click='EditModule(row.entity[col.field]);' ><span class='glyphicon glyphicon-pencil'></span></button>" }
          

          ]


};
    $scope.AddModule = function () {
        var resource = 'Module';
        HeartbeatService.PostDataToApi($scope.AddSuccess, $scope.Error, resource, $scope.Module);

    };

    $scope.AddSuccess = function (response) {
        alert ("Added module successfully");
        $('#dismiss').click();
     
    };

    $scope.Error = function (result) {

        alert("FAILED : " + result.status + ' ' + result.statusText);
    };

    $scope.ModuleSearch = function () {

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

        var resource = 'Module?ModuleName=' + name;
        HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);

    };

    $scope.SearchSuccess = function (data) {
        $scope.Modules = data;
        $scope.$apply();
    };



    $scope.EditModule = function (ModuleId) {
        var resource = 'Module?ModuleId=' + ModuleId;
        HeartbeatService.GetData($scope.GetSuccess, $scope.Error, resource);
    };

    $scope.GetSuccess = function (response) {
        $scope.Module = response;
        $scope.$apply();
        $('#editbtn').click();
    };
    $scope.UpdateModule = function () {
        var resource = 'Module/' + $scope.Module.ModuleId;
        HeartbeatService.PutData($scope.EditSuccess, $scope.Error, resource, $scope.Module);
    };
    $scope.EditSuccess = function (response) {
        alert("Updated successfully");
    };

    $scope.GetSuccessEditModule = function (response) {
        $scope.Module = response[0];
        $scope.ModuleName = response[0].ModuleName;
        // $scope.$apply();
        $scope.ShowModuleEditForm();
        $('#moduleClose').click();
        $('#editbtnins').click();
    };

    $scope.ShowModuleEditForm = function () {
        var companyId = $('#companyModule').val();
        var resource = "Module?companyId=" + companyId + '&ModuleName=-1';
        HeartbeatService.GetData($scope.ModuleEditLookupSuccess, $scope.Error, resource);
    }

    $scope.ModuleEditLookupSuccess = function (data) {
        $scope.AllModule = data;
        angular.forEach(data, function (item, index) {
            if (item.ModuleName == $scope.ModuleName) {
                $scope.SelectedModule = item;
            }
        });
        //$scope.SelectedInsurance = ($scope.AllInsurances.InsuranceId.indexOf($scope.InsuranceId) !== -1);
        //$scope.SelectedInsurance.InsuranceId = 2;
        $scope.$apply();
    }











   
});