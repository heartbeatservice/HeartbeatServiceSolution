HeartbeatApp.factory('HeartbeatService', function () {

    return {

        serviceAuthor: { 'Name': 'Umais Siddiqui' },

        GetData: function (callSuccess, wrong, resource) {
            request = $.ajax({
                beforeSend: function (xhrObj) {
                    xhrObj.setRequestHeader("Content-Type", "application/json");
                    xhrObj.setRequestHeader("Accept", "application/json");
                },

                // url: "http://presciencerx.azurewebsites.net/api/" + resource,
                url: "http://localhost:56799/api/" + resource,

                type: "get",

                success: function (response) { callSuccess(response); },
                error: function (result) { wrong(result); }
            });
        },

        PostData: function (callSuccess, wrong, resource, params) {
            request = $.ajax({
                beforeSend: function (xhrObj) {
                    xhrObj.setRequestHeader("Content-Type", "application/json");
                    xhrObj.setRequestHeader("Accept", "application/json");
                },
                url: "http://localhost:56799/api/" + resource,
                type: "post",
                data: JSON.stringify(params),
                success: function (response) { callSuccess(response); },
                error: function (result) { wrong(result); }
            });
        },
        GetDataByParams: function (callSuccess, wrong, resource, params) {

            request = $.ajax(
            {
               // url: "http://presciencerx.azurewebsites.net/api/" + resource,
                url: "http://localhost:56799/api/" + resource,
                type: "GET",
                contentType: "application/json",
                data: 'json=' + JSON.stringify(params),
                success: function (response) { callSuccess(response); },
                error: function (result) { wrong(result); }
            });

        
        }

    }

});