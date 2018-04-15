angular.module('app.users', [])

    .controller('UsersController', function ($scope, $http) {
        var URL = 'http://localhost:52976/MasterzAPI.svc';
        $scope.users = [];
        $scope.user = {};
        GetUsers(0);

        function GetUsers() {
            var param = { 'statusid': 0 };
            $http({
                method: 'GET',
                url: URL + '/GetUsers',
                data: param
            }).then(function createSuccess(response) {
                if (response.data) {
                    $scope.users = response.data;
                }
            }, function createError(response) {
                console.error(response.statusText);
            });
        };
        $scope.open = function () {
            $scope.showModal = true;
        };

        $scope.ok = function () {
            $scope.showModal = false;
        };

        $scope.cancel = function () {
            $scope.showModal = false;
        };
       
    });