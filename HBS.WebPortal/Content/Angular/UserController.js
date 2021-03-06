﻿HeartbeatApp.controller("UserController", function AppController($scope, $location, $filter, HeartbeatService) {
    $scope.CompanyId = $('#company').val();
    $scope.UserId = $('#User').val();
    $scope.RoleId = $('#role').val();
    $scope.IsSuperAdmin = false;
    $scope.SearchParam = '';
    $scope.Users = {};
    $scope.AllCompany = {};
    $scope.AllRole = {};
    $scope.AllModule = {};
    $scope.clearUser = function () {

        $scope.User = {};

    };
    $scope.init = function () {
        if ($scope.RoleId == 1) {
            var resource = 'Company?companyName=';
            HeartbeatService.GetData($scope.CompanySuccess, $scope.Error, resource);
            resource = 'User?RoleName='
            HeartbeatService.GetData($scope.RoleSuccess, $scope.Error, resource);
            $scope.IsSuperAdmin = true;
        }
        else {
            $('#divadmin').hide();
            $('#diveditadmin').hide();
            $scope.IsSuperAdmin = false;
        }
        resource = 'Module?CompanyId=-1&ModuleName=';
        HeartbeatService.GetData($scope.ModuleSuccess, $scope.Error, resource);
    };
    $scope.CompanySuccess = function (data) {
        $scope.AllCompany = data;
        $scope.$apply();
    };
    $scope.RoleSuccess = function (data) {
        $scope.AllRole = data;
        $scope.$apply();
    };
    $scope.ModuleSuccess = function (data) {
        $scope.AllModule = $filter('filter')(data, { IsForAll: "false" }); //data;
        $scope.$apply();
    };
    $scope.GridOptions = {
        data: 'Users',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'UserName', displayName: 'User Name', enableCellEdit: true, width: 100 },
                     { field: 'FirstName', displayName: 'First Name', enableCellEdit: true, width: 100 },
                      { field: 'LastName', displayName: 'Last Name', enableCellEdit: true, width: 100 },
                      { field: 'Email', displayName: 'Email', enableCellEdit: true, width: 100 },



         { field: 'UserId', displayName: 'View/Edit', enableCellEdit: true, width: 100, cellTemplate: "<button style='margin-left:20px;' class='btn-small btn-danger' ng-click='EditUser(row.entity[col.field]);' ><span class='glyphicon glyphicon-pencil'></span></button>" },
         // 
        ]



    };
    $scope.AddUser = function () {
        if ($scope.RoleId != 1) {
            $scope.User.CompanyId = $scope.CompanyId;
            $scope.User.RoleId = 3;
        }
        var resource = 'User';
        HeartbeatService.PostDataToApi($scope.AddSuccess, $scope.Error, resource, $scope.User);

    };

    $scope.AddSuccess = function (response) {
        if (response != -1) {
            alert("Added User successfully");
            $('#dismiss').click();
        }
        else {
            alert("User already exists!");            
        }


    };

    $scope.Error = function (result) {

        alert("FAILED : " + result.status + ' ' + result.statusText);
    };

    $scope.UserSearch = function () {

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
        if ($scope.RoleId == 1) {
            var resource = 'User?UserName=' + name;
            HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);
        }
        else {
            var resource = 'User?UserName=' + name + '&CompanyId=' + $scope.CompanyId;
            HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);
        }

    };

    $scope.SearchSuccess = function (data) {
        $scope.Users = data;
        $scope.$apply();
    };



    $scope.EditUser = function (User) {
        $scope.User = {};
        var resource = 'User?id=' + User;
        HeartbeatService.GetData($scope.GetSuccess, $scope.Error, resource);
    };
    $scope.GetSuccess = function (response) {
        $scope.User = response;
        $scope.User.Password1 = $scope.User.Password;
        //$scope.User.RoleId = { selected: response. }; 
        $scope.ChangeModule();
        $scope.ModuleShowHide();
        $('#editbtn').click();
    };
    $scope.UpdateUser = function () {
        var resource = 'User';
        if ($scope.RoleId != 1) {
            $scope.User.CompanyId = $scope.CompanyId;
            $scope.User.RoleId = 3;
        }
        HeartbeatService.PutData($scope.EditSuccess, $scope.Error, resource, $scope.User);
    };
    $scope.EditSuccess = function (response) {
        alert("Updated successfully");
        $('#dismissedit').click();
    };

    $scope.ModuleShowHide = function () {
        if ($scope.User.RoleId == 1 || $scope.User.RoleId == 2)
            $("#divModule").hide();
        else
            $("#divModule").show();
    }
    $scope.ModuleShowHideAddForm = function () {
        if ($scope.User.RoleId == 1 || $scope.User.RoleId == 2)
            $("#divaddModule").hide();
        else
            $("#divaddModule").show();
    }
    $scope.ChangeModule = function () {
        resource = 'Module?CompanyId=' + $scope.User.CompanyId + '&ModuleName=';
        HeartbeatService.GetData($scope.ModuleSuccess, $scope.Error, resource);
    }
});