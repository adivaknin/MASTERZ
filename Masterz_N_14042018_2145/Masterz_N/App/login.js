angular.module('app.login', [])

    .controller('LoginController', function ($scope, $http) {

        //Login();

        //function Login() {
            var URL = 'http://localhost:52976/MasterzAPI.svc';
            $scope.users = [];
            var param = { 'statusid': 0 };
            $http({
                method: 'GET',
                url: URL + '/GetUsers',
                data: param
            }).then(function createSuccess(response) {
                if (response.data) {
                    $scope.users = response.data;
                    var loggedin = false;
                    var users = $scope.users.length;
                    var username = $scope.username;
                    var password = $scope.password;

                    for (i = 0; i < users; i++) {
                        if ($scope.users[i].name === username && $scope.users[i].password === password) {
                            loggedin = true;
                            break;
                        }
                    }
                    if (loggedin === true) {
                        alert("login successful");
                        $location.path("/loggedin");
                    } else {
                        alert("username does not exist")
                    }
                }
            }, function createError(response) {
                console.error(response.statusText);
            });
        //};

    });