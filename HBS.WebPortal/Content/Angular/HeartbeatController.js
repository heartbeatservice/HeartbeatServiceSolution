HeartbeatApp.controller("HeartbeatController", function AppController($scope, $location, HeartbeatService) {
   
    $scope.menuItems = [{ name: 'Home', cls: 'nav active', url: 'home/index' }, { name: 'About Us', cls: 'nav', url: 'home/about', submenu: [{ name: 'Vision', url: 'home/about' }, { name: 'Meet The Team', url: 'home/team' }] }, { name: 'Contact Us', cls: 'nav', url: 'Home/Contact' }];


    $scope.url = $location.host();
    $scope.path = $location.path();
    $scope.port = $location.port();
    $scope.init = function () {

        $scope.constructMenu();
        $('#fullcalendar').mouseover(function () { $(this).css('cursor', 'pointer'); });
        if ($('#fullcalendar') != undefined) {
            $('#fullcalendar').fullCalendar({
                selectable:true,
                dayClick: function (date, allDay, jsEvent, view) {
                    
                    if (allDay) {
                       // alert('Clicked on the entire day: ' + date);
                    } else {
                        alert('Clicked on the slot: ' + date);
                    }


                    // change the day's background color just for fun
                   // $(this).css('background-color', 'red');

                },
                select: function (startDate, endDate, allDay, jsEvent, view) {
                    alert("Selected");
                }

            });
        }
    };
    $scope.loginSucess = function (response) {
        $scope.User = response;
        if ($scope.User.UserId > 0) {
            $scope.menuItems = [{ name: 'Schedule', cls: 'nav active', url: 'home/index' }, { name: 'Appointment', cls: 'nav', url: 'home/about', submenu: [{ name: 'Vision', url: 'home/about' }, { name: 'Meet The Team', url: 'home/team' }] }, { name: 'Admin', cls: 'nav', url: 'Home/Contact' }];

            $scope.constructMenu();
            $scope.$apply();
           window.location.href = "/Scheduling?session="+$scope.User.UserId;
        }
    };

    $scope.ErrorLogin = function (error) {
        alert('something went wrong');
    };

    $scope.ValidateUser = function () {
 
        var obj = { "UserName": "Waleed", "Password": "welcome" };
       obj.UserName=$('#user').val();
       obj.Password = $('#pass').val();
       HeartbeatService.PostData($scope.loginSucess, $scope.ErrorLogin, 'Security',obj );
       
    };
   
    $scope.constructMenu = function () {
        var mainMenu = document.getElementById('menu');
        var menuItem;
        var submenu;
        var submenuitem;
        mainMenu.innerHTML='';
        for (var i = 0; i < $scope.menuItems.length; i++) {

            menuItem = document.createElement('li');
            if ($scope.menuItems[i].submenu === undefined) {


                menuItem.setAttribute("class", "nav");
                menuItem.innerHTML = '<a href=http://' + $scope.url + ':' + $scope.port + '/' + $scope.menuItems[i].url + '/>' + $scope.menuItems[i].name + '</a>';
            }
            else {
                menuItem.setAttribute("class", "dropdown");
                
                menuItem.onmouseover = function () { this.setAttribute("class", "dropdown open"); };
                menuItem.onmouseout = function () { this.setAttribute("class", "dropdown"); };
                menuItem.innerHTML = '<a data-toggle=dropdown class=dropdown-toggle href=http://' + $scope.url + ':' + $scope.port + '/' + $scope.menuItems[i].url + '/>' + $scope.menuItems[i].name + '<b class=caret></b></a>';
                submenu = document.createElement('ul');
                submenu.setAttribute("class", "dropdown-menu");
                for (j = 0; j < $scope.menuItems[i].submenu.length; j++)
                {
                    submenuitem = document.createElement('li');
                    submenuitem.innerHTML = '<a  href=http://' + $scope.url + ':' + $scope.port + '/' + $scope.menuItems[i].submenu[j].url + '/>' + $scope.menuItems[i].submenu[j].name + '</a>';
                   submenu.appendChild(submenuitem);
                }
                menuItem.appendChild(submenu);
            }
            mainMenu.appendChild(menuItem);
        }


    };
    //End of Scope Function
}
);