HeartbeatApp.controller("ApointmentController", function AppController($scope, $location, HeartbeatService) {

    $scope.CompanyId = $('#company').val();
    $scope.SearchParam = '';
    $scope.Apointments = {};
    //$scope.CompanyId = 0;
    $scope.professionalId = 0;
    $scope.ProfessionalInfo = { ProfessionalId: 0, FirstName: '', LastName: '' };
    $scope.CustomerList = [];
    $scope.ProfessionalList = [];
    $scope.CustomerId = 0;
    $scope.init = function () {
        $("#StartDate").kendoDatePicker({ format: "yyyy-MM-dd" });
        $("#EndDate").kendoDatePicker({ format: "yyyy-MM-dd" });


        $scope.GetProfessionals();
        $scope.GetCustomers();
        if ($("#dashboardFlag").val() == "true") {
            var resource = 'Appointment?companyId=' + $('#company').val() + '&dashboardFlag=true'
            HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);
        }
    }
    $scope.GetProviders = function () {
        var resource = 'Apointment?ApointmentName=';
        HeartbeatService.GetData($scope.LoadProviders, $scope.Error, resource);
    };

    $scope.LoadProviders = function (response) {

        $scope.AllProviders = response;
    };


    $scope.GridOptions = {
        data: 'Apointments',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'CustomerName', displayName: 'Customer Name', enableCellEdit: true, width: 150 },
                     { field: 'CustomerDOB', displayName: 'Customer DOB', enableCellEdit: true, width: 150, cellFilter: "date:'MM-dd-yyyy'" },
        { field: 'CustomerPhone', displayName: 'Customer Phone', enableCellEdit: true, width: 150 },
        { field: 'CustomerAddress', displayName: 'Customer Address', enableCellEdit: true, width: 250 },
{ field: 'AppointmentStartTime', displayName: 'Start Time', enableCellEdit: true, width: 150 },
{ field: 'CustomerEmailAddress', displayName: 'Mail To', enableCellEdit: true, width: 150, cellTemplate: '<a href="mailto:{{row.getProperty(col.field)}}">{{row.getProperty(col.field)}}</a>' }

        ]


    };
   
    $scope.ApointmentSearch = function () {
        var resource = 'Appointment?companyId=' + $('#company').val()
        if ($scope.customerId != undefined)
            resource += '&customerId=' + $scope.customerId;
        resource += '&professionalId=' + $scope.professionalId +
                        '&startdate=' + $('#StartDate').val();
        if ($('#EndDate').val() != '')
            resource += '&enddate=' + $('#EndDate').val();
        HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);

    };

    $scope.SearchSuccess = function (data) {
        $scope.Apointments = data;
        $scope.$apply();
    };


    $scope.GetProfessionals = function () {

        //Get the Provider Info And Update the Label for that Provider on Calendar Page
        var resource = 'Professional?CompanyId=' + $('#company').val();
        HeartbeatService.GetData($scope.PopulateProviders, $scope.Error, resource);
        //Next Step in this process will be to load the drop down with Users and Select the Correct one. Thinking of using Ng-Model
    };
    $scope.PopulateProviders = function (response) {
        $scope.ProfessionalList = response;
       
        $scope.ProfessionalList = $scope.ProfessionalList.reverse();
        //$scope.findCurrentProvider();
        $scope.$apply();
    };

    $scope.GetCustomers = function () {

        //Get the Provider Info And Update the Label for that Provider on Calendar Page
        var resource = 'Customer?companyId=' + $('#company').val();
        HeartbeatService.GetData($scope.PopulateCustomers, $scope.Error, resource);
        //Next Step in this process will be to load the drop down with Users and Select the Correct one. Thinking of using Ng-Model
    };
    $scope.PopulateCustomers = function (response) {
        $scope.CustomerList = response;
        
        $scope.$apply();
    };

});