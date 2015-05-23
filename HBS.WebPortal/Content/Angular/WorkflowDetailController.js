HeartbeatApp.controller("WorkflowDetailController", function AppController($scope, $location, HeartbeatService) {

    $scope.CompanyId = $('#company').val();
    $scope.SearchParam = '';
    $scope.Filters = {};
    $scope.Filter = {};
    $scope.UserId = 0;
    $scope.OwnerId = 0;
    $scope.WorkflowStatusId = 0;
    $scope.WorkflowStatu = 0;
    $scope.WorkflowCategoryId = 0;
    $scope.UserInfo = { UserId: 0, text: '' };
    $scope.UserList = [];
    $scope.WStatus = [];
    $scope.WorkflowCategory = [];
    
    $scope.init = function () {
        $("#DueDate").kendoDatePicker({ format: "yyyy-MM-dd" });
        $("#DueDateMore").kendoDatePicker({ format: "yyyy-MM-dd" });
        $scope.GetUsers();
        
        $scope.GetCategory();
        $scope.GetWorkflowStatus();
    }
   


    $scope.GridOptions = {
        data: 'Filters',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'WorkflowTitle', displayName: 'Title', enableCellEdit: true, width: 160 },
        { field: 'WorkerName', displayName: 'Worker', enableCellEdit: true, width: 160 },
        { field: 'OwnerName', displayName: 'Owner', enableCellEdit: true, width: 160 },
        { field: 'StatusName', displayName: 'Status', enableCellEdit: true, width: 160 },
        { field: 'CategoryName', displayName: 'Category', enableCellEdit: true, width: 160 },
        { field: 'DueDate', displayName: 'Due Date', enableCellEdit: true, width: 160, cellFilter: "date:'MM-dd-yyyy'" },
        //{ field: 'MoreInfo', displayName: 'More Info', enableCellEdit: true, width: 110 }
        { field: 'WorkflowID', displayName: 'More Info', enableCellEdit: true, width: 150, cellTemplate: "<a href='#' style='margin-left:20px;' ng-click='EditWorkflowDetail(row.entity[col.field]);' >More Info</a>" }


        ]


    };
   
    $scope.FilterSearch = function () {
        if ($('#DueDate').val() == '' || $('#DueDate').val() == null) {
            var resource = 'WorkflowDetail?CompanyId=' + $('#company').val() + '&ownerId=' + $scope.OwnerId + '&workerId=' + $scope.UserId + '&statusId=' + $scope.WorkflowStatu + '&categoryId=' + $scope.WorkflowCategoryId;
            HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);
        }
        else
        {
        // var resource = 'WorkflowDetail?CompanyId=' + $('#company').val() + '&ownerId=' + $scope.OwnerId + '&workerId=' + $scope.UserId + '&statusId=' + $scope.WorkflowStatu + '&categoryId=' + $scope.WorkflowCategoryId + '&duedate=' + $('#DueDate').val();
        var resource = 'WorkflowDetail?CompanyId=' + $('#company').val() + '&ownerId=' + $scope.OwnerId + '&workerId=' + $scope.UserId + '&statusId=' + $scope.WorkflowStatu + '&categoryId=' + $scope.WorkflowCategoryId + '&duedate=' + $('#DueDate').val();
        HeartbeatService.GetData($scope.SearchSuccess, $scope.Error, resource);
        }

    };

    $scope.SearchSuccess = function (data) {
        $scope.Filters = data;
        $scope.$apply();
    };

    $scope.GetUsers = function () {

        //Get the Provider Info And Update the Label for that Provider on Calendar Page
        var resource = 'User?CompanyId=' + $('#company').val();
        HeartbeatService.GetData($scope.PopulateProviders, $scope.Error, resource);
        //Next Step in this process will be to load the drop down with Users and Select the Correct one. Thinking of using Ng-Model
    };
    $scope.PopulateProviders = function (response) {
        $scope.UserList = response;
        $scope.UserList = $scope.UserList.reverse();
        //$scope.findCurrentProvider();        
        $scope.$apply();
    };

    $scope.GetWorkflowStatus = function () {

        var resource = 'WorkflowStatus';
        HeartbeatService.GetData($scope.WorkflowStatusSeccess, $scope.Error, resource);
    };
    $scope.WorkflowStatusSeccess = function (data) {
        $scope.WStatus = data;
        $scope.$apply();
    };

    $scope.GetCategory = function () {

        var resource = 'WorkflowCategory?{"CompanyId":"' + $("#company").val() + '"}';
        HeartbeatService.GetData($scope.WorkflowCategorySeccess, $scope.Error, resource);
    };
    $scope.WorkflowCategorySeccess = function (data) {
        $scope.WorkflowCategory = data;
        $scope.$apply();
    };

    $scope.Error = function (error)
    {
        alert("Failed:" + error.status + ' ' + error.responseText);
    }
    

    $scope.EditWorkflowDetail = function (workflowid) {
        if (workflowid == undefined)
            return;
        var resource = 'WorkflowDetail?workflowDetailId=' + workflowid;
        HeartbeatService.GetData($scope.GetSuccess, $scope.Error, resource);
    };

    $scope.GetSuccess = function (response) {
        
        $scope.applyWorkflowDetailToModel(response);
        var prevId, nextId = 0;
        var isBreak = false;
        angular.forEach($scope.Filters, function (obj, index) {
            if(!isBreak)
            {
                if (nextId != 0) {
                    nextId = obj.WorkflowID;
                    isBreak = true;
                }
                else {
                    if (obj.WorkflowID != response.WorkflowID)
                        prevId = obj.WorkflowID;
                    else
                        nextId = obj.WorkflowID;
                }
            }
        });
        console.log(prevId);
        console.log(nextId);
        $scope.Workflow.PrevID = prevId;
        $scope.Workflow.NextID = nextId;
        if (response.DueDate != null) {
            $('#DueDateMore').val(response.DueDate.split('/')[2] + "-" + response.DueDate.split('/')[0] + "-" + response.DueDate.split('/')[1]);
        }
        else
            $('#DueDateMore').val('');
        $('#morebtn').click();
    };

    $scope.applyWorkflowDetailToModel = function (response) {
        $scope.Workflow = response;
        $scope.$apply();
    }
});