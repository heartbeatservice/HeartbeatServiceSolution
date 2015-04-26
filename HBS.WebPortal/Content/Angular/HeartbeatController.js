HeartbeatApp.controller("HeartbeatController", function AppController($scope, $filter, $location, HeartbeatService) {
    $scope.CompanyId = $('#company').val();
    $scope.menuItems = [{ ModuleName: 'Home', cls: 'nav navbar-item active', ModuleURL: 'home/index' }, { ModuleName: 'About Us', cls: 'nav navbar-item ', ModuleURL: 'home/about' },
        { ModuleName: 'Products', cls: 'nav navbar-item ', ModuleURL: 'home/Products' }, { ModuleName: 'Services', cls: 'nav navbar-item', ModuleURL: 'home/Services' },
        { ModuleName: 'Goals and Vision', cls: 'nav navbar-item', ModuleURL: 'home/Goals' }, { ModuleName: 'Meet The Team', cls: 'nav navbar-item', ModuleURL: 'home/Team' },
        { ModuleName: 'Contact Us', cls: 'nav navbar-item', ModuleURL: 'Home/ContactUs' }];
    $scope.app = '';
    $scope.company = {};
    $scope.url = $location.host();
    $scope.path = $location.path();
    $scope.port = $location.port();
    $scope.homePath = $scope.url + ':' + $scope.port + '/' + $scope.menuItems[0].url;
    $scope.role = 0;
    $scope.init = function () {
        $scope.constructMenu();

    };
    //$scope.loginSucess = function (response) {
    //    $scope.User = response;
    //    if ($scope.User.UserId > 0) {
    //        $scope.menuItems = [{ name: 'Schedule', cls: 'nav active', url: 'home/index' }, { name: 'Appointment', cls: 'nav', url: 'home/about', submenu: [{ name: 'Vision', url: 'home/about' }, { name: 'Meet The Team', url: 'home/team' }] }, { name: 'Admin', cls: 'nav', url: 'Home/Contact' }];

    //        $scope.constructMenu();
    //        $scope.$apply();
    //       window.location.href = "/Scheduling?session="+$scope.User.UserId;
    //    }
    //};

    //$scope.ErrorLogin = function (error) {
    //    alert('something went wrong');
    //};

    //$scope.ValidateUser = function () {

    //    var obj = { "UserName": "Waleed", "Password": "welcome" };
    //   obj.UserName=$('#user').val();
    //   obj.Password = $('#pass').val();
    //   HeartbeatService.PostData($scope.loginSucess, $scope.ErrorLogin, 'Security',obj );

    //};

    $scope.constructMenu = function () {
        var url = $location.absUrl();

        var start = url.toLowerCase().indexOf("home");

        var page = url.substring(start);

        var app = document.getElementById('app').value;
        if ($scope.CompanyId == undefined || $scope.CompanyId == null || $scope.CompanyId == 0) {
            $scope.buildMenu();
        }
        else {
            $scope.role = document.getElementById('role').value;
            
            var user = document.getElementById('user').value;

            var resource = 'Module?companyId=' + $scope.CompanyId + '&userId=' + user + '&role=' + $scope.role;
            HeartbeatService.GetData($scope.GetSuccess, $scope.Error, resource);
            if ($scope.role == 1) {
                resource = 'Company';
                HeartbeatService.GetData($scope.GetCompanySuccess, $scope.Error, resource);
            }
            else {
                resource = 'Company?companyId=' + $scope.CompanyId;
                HeartbeatService.GetData($scope.GetCompanySuccess, $scope.Error, resource);
            }
        }
    };

    $scope.GetCompanySuccess = function (data) {
        if (data != null)
            $scope.company = data;
        if ($scope.role == 1) {
            if ($scope.CompanyId != 0)
            {
                var item = $filter('filter')(data, { CompanyId: $scope.CompanyId });
                $('button.button-label').html(item.CompanyName);
                $('#company').val(item.CompanyId);
            }
            $("#companylst").show();
            $("#companyname").hide();
        }
        else {
            $("#companylst").hide();
            $("#companyname").show();
            $("#compname").html($scope.company.CompanyName);
        }

            //$scope.buildCompany();
            $scope.$apply();
    };

    $scope.GetSuccess = function (data) {
        if (data != null)
            $scope.menuItems = data;
        $scope.$apply();
        $scope.buildMenu();
    };
    $scope.buildMenu = function () {
        var url = $location.absUrl();

        var start = url.toLowerCase().indexOf("home");

        var page = url.substring(start);

        var mainMenu = document.getElementById('side-menu');
        var menuItem;
        var submenu;
        var submenuitem;
        mainMenu.innerHTML = '';
        for (var i = 0; i < $scope.menuItems.length; i++) {

            menuItem = document.createElement('li');

            if ($scope.menuItems[i].SubModule === undefined || $scope.menuItems[i].SubModule === null) {

                if (start === -1)
                    page = 'home/index';
                if (page.toLowerCase().indexOf($scope.menuItems[i].ModuleURL.toLowerCase()) === 0)
                    $scope.menuItems[i].cls = 'nav navbar-item active';

                else

                    $scope.menuItems[i].cls = 'nav navbar-item';


                menuItem.setAttribute("class", $scope.menuItems[i].cls);

                menuItem.innerHTML = '<a href=http://' + $scope.url + ':' + $scope.port + '/' + $scope.menuItems[i].ModuleURL + '/><i class="fa ' + $scope.menuItems[i].IconName + ' fa-fw"></i> ' + $scope.menuItems[i].ModuleName + '</a>';
            }
            else {
                menuItem.setAttribute("class", "dropdown");

                //menuItem.onmouseover = function () { this.setAttribute("class", "dropdown open dropText "); };
                //menuItem.onmouseout = function () { this.setAttribute("class", "dropdown dropText"); };
                menuItem.innerHTML = '<a data-toggle=dropdown class="dropdown-toggle dropText" href=http://' + $scope.url + ':' + $scope.port + '/' + $scope.menuItems[i].ModuleURL + '/><i class="fa ' + $scope.menuItems[i].IconName + ' fa-fw"></i> ' + $scope.menuItems[i].ModuleName + '<span class="fa arrow"></span></a>';
                submenu = document.createElement('ul');
                submenu.setAttribute("class", "dropdown-menu dropText submenu");
                for (j = 0; j < $scope.menuItems[i].SubModule.length; j++) {
                    submenuitem = document.createElement('li');
                    submenuitem.setAttribute("class", "subitem");
                    submenuitem.innerHTML = '<a  class="dropText" href=http://' + $scope.url + ':' + $scope.port + '/' + $scope.menuItems[i].SubModule[j].ModuleURL + '/>' + $scope.menuItems[i].SubModule[j].ModuleName + '</a>';
                    submenu.appendChild(submenuitem);
                }
                menuItem.appendChild(submenu);
            }
            mainMenu.appendChild(menuItem);
        }


    };

    //$scope.buildCompany = function () {

    //    var mainMenu = document.getElementById('dropdownmenu');
    //    var menuItem;
    //    mainMenu.innerHTML = '';
    //    for (var i = 0; i < $scope.company.length; i++) {

    //        menuItem = document.createElement('li');

    //        menuItem.innerHTML = '<a tabindex="-1" ng-click="selectVal(item)"/><i class=""></i> ' + $scope.company[i].CompanyName + '</a>';
    //        mainMenu.appendChild(menuItem);
    //    }
    //};
    $scope.selectVal = function (item) {
        //switch (attrs.menuType) {
        //    case "button":
        $('button.button-label').html(item.CompanyName);
        $('#company').val(item.CompanyId);
        //        break;
        //    default:
        //        $('a.dropdown-toggle', element).html('<b class="caret"></b> ' + item.name);
        //        break;
        //}

    };
    //$scope.doSelect({
    //    selectedVal: item.CompanyId
    //});
    ////End of Scope Function
}
);