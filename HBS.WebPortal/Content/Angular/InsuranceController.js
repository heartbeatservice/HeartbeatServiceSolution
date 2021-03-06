﻿HeartbeatApp.controller("InsuranceController", function AppController($scope, $location, HeartbeatService) {

    $scope.CompanyId = $('#company').val();
    $scope.SearchParam = '';
    $scope.Insurances = {};
    $scope.Insurance = {};
    $scope.clearInsurance = function () {

        $scope.Insurance = {};

    };
    $scope.GridOptions = {
        data: 'Insurances',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'InsuranceName', displayName: 'Insurance Name', enableCellEdit: true, width: 200 },
                     { field: 'InsuranceAddress', displayName: 'Insurance Address', enableCellEdit: true, width: 200 },
                     { field: 'InsurancePhone', displayName: 'Insurance Phone', enableCellEdit: true, width: 200 },
               { field: 'InsuranceWebsite', displayName: 'Insurance Website', enableCellEdit: true, width: 200 },


         { field: 'InsuranceId', displayName: 'View/Edit', enableCellEdit: true, width: 100, cellTemplate: "<button style='margin-left:20px;' class='btn-small btn-danger' ng-click='EditInsurance(row.entity[col.field]);' ><span class='glyphicon glyphicon-pencil'></span></button>" },
         // 
        ]



    };
    $scope.AddInsurance = function () {
        $scope.Insurance.CompanyId = $('#company').val();
        $scope.Insurance.CreatedBy = $('#user').val();
        $scope.Insurance.Active = true;
        var resource = 'Insurance';
        HeartbeatService.PostDataToApi($scope.AddSuccess, $scope.Error, resource, $scope.Insurance);

    };

    $scope.AddSuccess = function (response) {
        alert("Added insurance successfully");
        $('#dismiss').click();

    };

    $scope.Error = function (result) {

        alert("FAILED : " + result.status + ' ' + result.statusText);
    };

    $scope.InsuranceSearch = function () {

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

        var resource = 'Insurance?companyId=' + $scope.CompanyId + '&InsuranceName=' + name;
        HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);
    };
    $scope.SearchSuccess = function (data) {
        $scope.Insurances = data;
        $scope.$apply();
    };
    $scope.EditInsurance = function (InsuranceId) {
        var resource = 'Insurance?InsuranceId=' + InsuranceId;
        HeartbeatService.GetData($scope.GetSuccess, $scope.Error, resource);
    };
    $scope.GetSuccess = function (response) {
        $scope.Insurance = response;
        $scope.$apply();
        $('#editbtn').click();
    };
    $scope.UpdateInsurance = function () {
        var resource = 'Insurance/' + $scope.Insurance.InsuranceId;
        HeartbeatService.PutData($scope.EditSuccess, $scope.Error, resource, $scope.Insurance);
    };
    $scope.EditSuccess = function (response) {
        alert("Updated successfully");
        $scope.InsuranceSearch();
        $('#dismissEdit').click();
    };
    $scope.resetInsurance = function () {
        var resource = 'Insurance?InsuranceId=' + $scope.Insurance.InsuranceId;
        HeartbeatService.GetData($scope.GetResetSuccess, $scope.Error, resource);
    };
    $scope.GetResetSuccess = function (response) {
        $scope.Insurance = response;
        $scope.$apply();       
    };
});