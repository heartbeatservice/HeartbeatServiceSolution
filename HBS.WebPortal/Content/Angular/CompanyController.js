HeartbeatApp.controller("CompanyController", function AppController($scope, $location,$filter, HeartbeatService) {
    $scope.RoleId = $('#role').val();
    $scope.CompanyId = $('#company').val();
    $scope.SearchParam = '';
    $scope.Companies = [];
    $scope.Company = {};
    $scope.AllModule = {};
    $scope.clearCompany = function () {

        $scope.Company = {};
        $scope.Company.LstModules = {};
    };
    $scope.init = function () {
        if ($scope.RoleId == 1) {
            resource = 'Module?CompanyId=-1&ModuleName=';
            HeartbeatService.GetData($scope.ModuleSuccess, $scope.Error, resource);
            $('#divbtn').show();
            $('#divSearch').show();
        }
        else if ($scope.RoleId == 2) {
            $('#divbtn').hide();
            $('#divSearch').hide();
            var resource = 'Company?companyId=' + $scope.CompanyId;
            HeartbeatService.GetData($scope.CompanySuccess, $scope.Error, resource);
        }
        
    };
    $scope.CompanySuccess = function (data) {
        $scope.Companies.push(data);
        $scope.$apply();
    };
    $scope.ModuleSuccess = function (data) {
        $scope.AllModule = $filter('filter')(data, { IsForAll: "false" });
        $scope.$apply();
    };
    $scope.GridOptions = {
        data: 'Companies',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'CompanyName', displayName: 'Company Name', enableCellEdit: true, width: 200 },
                     { field: 'Description', displayName: 'Description', enableCellEdit: true, width: 200 },
                      { field: 'CompanyId', displayName: 'View/Edit', enableCellEdit: true, width: 100, cellTemplate: "<button style='margin-left:20px;' class='btn-small btn-danger' ng-click='EditCompany(row.entity[col.field]);' ><span class='glyphicon glyphicon-pencil'></span></button>" }
                   


         //{ field: 'CompanyId', displayName: 'View/Edit', enableCellEdit: true, width: 100, cellTemplate: "<button style='margin-left:20px;' class='btn-small btn-danger' ng-click='EditCompany(row.entity[col.field]);' ><span class='glyphicon glyphicon-pencil'></span></button>" },
         // 
        ]



    };
    $scope.AddCompany = function () {
        //$scope.Company.CompanyName = $('#company').val();
        //$scope.Company.Description = $('#Description').val();
        var resource = 'Company';
        HeartbeatService.PostDataToApi($scope.AddSuccess, $scope.Error, resource, $scope.Company);

    };

    $scope.AddSuccess = function (response) {
        alert("Added Company successfully");
        $('#dismiss').click();
        $scope.CompanySearch();
    };

    $scope.Error = function (result) {

        alert("FAILED : " + result.status + ' ' + result.statusText);
    };

    $scope.CompanySearch = function () {

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

        var resource = 'Company?companyName=' + name;
        HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);

    };

    $scope.SearchSuccess = function (data) {
        $scope.Companies = data;
        $scope.$apply();
    };



    $scope.EditCompany = function (Company) {
        var resource = 'Company?companyId=' + Company;
        HeartbeatService.GetData($scope.GetSuccess, $scope.Error, resource);
    };
    $scope.GetSuccess = function (response) {
        $scope.Company = response;
        $scope.$apply();
        $('#editbtn').click();
        if ($scope.RoleId == 2) {
            $("#divModule").hide();
        }
        else {
            $("#divModule").show();
        }
    };
    $scope.UpdateCompany = function () {
        var resource = 'Company/' + $scope.Company.CompanyName;
        HeartbeatService.PutData($scope.EditSuccess, $scope.Error, resource, $scope.Company);
    };
    $scope.EditSuccess = function (response) {
        alert("Updated successfully");
        $scope.CompanySearch();
        $('#dismissEdit').click();
    };
});